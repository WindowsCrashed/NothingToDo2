using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    [SerializeField] Transform movePoint;
    [SerializeField] Transform snake;

    Transform parentTransform;

    void Awake()
    {
        parentTransform = transform.parent.transform;
        transform.SetParent(snake);
    }

    void MoveToMovePoint()
    {
        transform.position = movePoint.position;
    }

    void ChangeMovePointPosition()
    {
        movePoint.position = parentTransform.position;
    }

    public void MoveBody()
    {
        ChangeMovePointPosition();
        MoveToMovePoint();
        
    }
}
