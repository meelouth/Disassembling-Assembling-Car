﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTheCamera : MonoBehaviour
{
    private Transform cameraTransform;
    private Transform objectTransform;
    
    void Start()
    {
        cameraTransform = FindObjectOfType<Camera>().transform;
        objectTransform = transform;
        LookToCamera();
    }
    
    void Update()
    {
        LookToCamera();
    }

    private void LookToCamera()
    {
        if (!cameraTransform)
        {
            Debug.Log("Camera is missing!");
            return;
        }

        Quaternion rotation = cameraTransform.rotation;
        objectTransform.LookAt(transform.position + rotation * Vector3.forward, 
        rotation * Vector3.up);
    }
}
