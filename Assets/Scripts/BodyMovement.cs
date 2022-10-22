using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour, ISnake
{
    [SerializeField] Transform spawnPoint;

    Vector3 parentShadowPosition;
    Vector3 parentShadowRotation;

    public Transform Parent { get; private set; }

    void Start()
    {
        SetShadow();
    }

    void MoveToShadow()
    {
        transform.SetPositionAndRotation(parentShadowPosition, Quaternion.Euler(parentShadowRotation));
    }

    void SetShadow()
    {
        parentShadowPosition = Parent.position;
        parentShadowRotation = Parent.localEulerAngles;
    }

    public void MoveBody()
    {                      
        MoveToShadow();
        SetShadow();        
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void SetParentTransform(Transform parent)
    {
        Parent = parent;
    }
}
