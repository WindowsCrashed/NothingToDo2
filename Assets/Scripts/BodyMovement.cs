using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour, ISnake
{
    [SerializeField] Transform movePoint;
    [SerializeField] Transform backPoint;
    [SerializeField] Transform snake;

    Transform parentBackPoint;
    Transform parentTransform;
    
    void Awake()
    {
        //ISnake parentPart = (ISnake) transform.parent;
        
        if (transform.parent.TryGetComponent(out BodyMovement parent))
        {
            Transform parentBackPoint = parent.GetBackPoint();
        } else if (transform.parent.TryGetComponent(out HeadMovement parentHead))
        {
            Transform parentBackPoint = parentHead.GetBackPoint();
        }
        
        parentTransform = transform.parent.transform;

        transform.SetParent(snake);
    }

    void MoveToMovePoint()
    {
        Debug.Log(movePoint.position);
        transform.position = movePoint.position;
        //transform.position = parentBackPoint.position;
    }

    void ChangeMovePointPosition()
    {
        movePoint.position = parentTransform.position;
    }

    public void MoveBody()
    {                      
        MoveToMovePoint();
        ChangeMovePointPosition();
    }

    public Transform GetBackPoint()
    {
        return backPoint;
    }
}
