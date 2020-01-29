using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToDescriptionalObjects : MonoBehaviour
{
    private Camera camera;

    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ThrowRaycast();
        }
    }

    private void ThrowRaycast()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            DescriptionOnWorldSpaceCanvas objectHit = hit.transform.GetComponent<DescriptionOnWorldSpaceCanvas>();

            if (!objectHit)
                return;
            
            objectHit.GetClick();
        }
    }
}
