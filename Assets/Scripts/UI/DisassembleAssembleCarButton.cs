using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisassembleAssembleCarButton : MonoBehaviour
{
    private enum CarState
    {
        ASSEMBLED,
        DISASSEMBLED
    }

    private CarState carState;
    
    private MovingPart[] movingParts;

    [SerializeField] private Text buttonText;

    private void Start()
    {
        movingParts = FindObjectsOfType<MovingPart>();
    }

    private void DisassembleObject()
    {
        foreach (var part in movingParts)
        {
            part.StartMovePartToPoint(part.endPoint);
        }

        buttonText.text = "Assemble Car";
        carState = CarState.DISASSEMBLED;
    }

    private void AssembleObject()
    {
        foreach (var part in movingParts)
        {
            part.StartMovePartToPoint(part.startingPoint);
        }

        buttonText.text = "Disassemble Car";
        carState = CarState.ASSEMBLED;
    }

    public void Press()
    {
        if (carState == CarState.ASSEMBLED)
        {
            DisassembleObject();
        }
        else
        {
            AssembleObject();
        }
    }
}
