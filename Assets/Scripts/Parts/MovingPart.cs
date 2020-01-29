using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPart : MonoBehaviour
{
    private enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        FORWARD,
        BACK
    }

    private Vector3[] directions = new Vector3[6];

    [SerializeField] private Direction direction;
    [SerializeField] private float distance = 3;
    [SerializeField] private float timeToReachEndPoint = 5;

    private bool isMoving;

    private Transform partTransform;
    
    [HideInInspector] public Vector3 endPoint;
    [HideInInspector] public Vector3 startingPoint;

    private Vector3 currentPoint;

    private void Start()
    {
        partTransform = transform;
        
        InitDirections();
        
        startingPoint = partTransform.localPosition;

        endPoint = startingPoint + GetDirection(direction) * distance;
        
    }
    
    private void Update()
    {
        if (!isMoving)
            return;
        
        MovePart(currentPoint);
        
        if (IsEndPointReached())
            StopMovePartToPoint();
    }

    private void MovePart(Vector3 to)
    {
        partTransform.localPosition = Vector3.Lerp(partTransform.localPosition, to, timeToReachEndPoint * Time.deltaTime);
    }

    public void StartMovePartToPoint(Vector3 to)
    {
        currentPoint = to;
        isMoving = true;
    }

    private void StopMovePartToPoint()
    {
        isMoving = false;
    }

    private Vector3 GetDirection(Direction dir)
    {
        return directions[(int) dir];
    }

    private bool IsEndPointReached()
    {
        return Vector3.Distance(partTransform.localPosition, endPoint) < Mathf.Epsilon;
    }

    private void InitDirections()
    {
        directions[0] = Vector3.up;
        directions[1] = Vector3.down;
        directions[2] = Vector3.left;
        directions[3] = Vector3.right;
        directions[4] = Vector3.forward;
        directions[5] = Vector3.back;
    }
}
