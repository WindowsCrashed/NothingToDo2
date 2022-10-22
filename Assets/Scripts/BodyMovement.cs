using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour, ISnake
{
    [SerializeField] Transform movePoint;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform snake;

    Transform parentBackPoint;
    Transform parentTransform;

    public Transform SpawnPoint => spawnPoint;
    public Transform ParentPosition { get; private set; }

    void Awake()
    {
        //ISnake parentPart = (ISnake) transform.parent;
        /*
        if (transform.parent.TryGetComponent(out BodyMovement parent))
        {
            Transform parentBackPoint = parent.GetBackPoint();
        } else if (transform.parent.TryGetComponent(out HeadMovement parentHead))
        {
            Transform parentBackPoint = parentHead.GetBackPoint();
        }
        */
        //parentTransform = transform.parent.transform;

        //transform.SetParent(snake);
    }

    void MoveToMovePoint()
    {
        transform.position = movePoint.position;
    }

    void ChangeMovePointPosition()
    {
        movePoint.position = ParentPosition.position;
        ChangeSpawnPointPosition();
    }

    void ChangeSpawnPointPosition()
    {
        spawnPoint.position = transform.position - movePoint.localPosition;
    }

    public void MoveBody()
    {                      
        MoveToMovePoint();
        ChangeMovePointPosition();
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void SetParentPosition(Transform parent)
    {
        ParentPosition = parent;
    }
}
