using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionOnWorldSpaceCanvas : MonoBehaviour
{
    public string name = "Name";
    [TextArea]
    public string description = "Description";

    [SerializeField] private GameObject worldSpaceCanvasPrefab;

    [SerializeField] private Vector3 spawnOffsetFromObject;

    private GameObject worldSpaceCanvasOnScene;
    

    private void SpawnWorldSpaceCanvas()
    {
        Transform spawnParent = transform;

        worldSpaceCanvasOnScene = Instantiate(worldSpaceCanvasPrefab, spawnParent);

        worldSpaceCanvasOnScene.transform.localPosition += spawnOffsetFromObject;
        
        SetText();
    }

    private void SetText()
    {
        Transform root = worldSpaceCanvasOnScene.transform.Find("Background");

        root.Find("Name").GetComponent<Text>().text = name;
        root.Find("Description").GetComponent<Text>().text = description;
    }

    private void DestroyWorldSpaceCanvas()
    {
        Destroy(worldSpaceCanvasOnScene);
    }

    public void GetClick()
    {
        if (worldSpaceCanvasOnScene)
        {
            DestroyWorldSpaceCanvas();
            return;
        }
        
        SpawnWorldSpaceCanvas();
    }
    
}
