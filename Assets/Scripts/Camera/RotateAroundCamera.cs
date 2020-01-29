using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCamera : MonoBehaviour
{
    public Transform target;

    [SerializeField] private float sensitivity = 0.05f;
    
    [SerializeField] private float distance = 15f;
    [SerializeField] private float xSpeed = 120.0f;
    [SerializeField] private float ySpeed = 120.0f;
 
    [SerializeField] private float yMinLimit = -20f;
    [SerializeField] private float yMaxLimit = 80f;

    private float x;
    private float y;

    private Transform cameraTransform;
    
    void Start () 
    {
        cameraTransform = transform;
        
        Vector3 angles = cameraTransform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }
 
    void LateUpdate () 
    {
        if (target && Input.GetMouseButton(1)) 
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * sensitivity;
            y -= Input.GetAxis("Mouse Y") * ySpeed * sensitivity;
 
            y = AngleExtension.ClampAngle(y, yMinLimit, yMaxLimit);
 
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;
 
            cameraTransform.rotation = rotation;
            cameraTransform.position = position;
        }
    }
}
