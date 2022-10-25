using UnityEngine;

public class BodyMovement : MonoBehaviour, ISnake
{
    [SerializeField] Transform spawnPoint;

    ShadowState shadow;

    public Transform Reference { get; private set; }

    void Start()
    {
        SetShadow();
    }

    void MoveToShadow()
    {
        transform.SetPositionAndRotation(shadow.Position, Quaternion.Euler(shadow.Rotation));
    }

    void SetShadow()
    {
        shadow = new ShadowState(Reference);
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

    public void SetReference(Transform reference)
    {
        Reference = reference;
    }
}
