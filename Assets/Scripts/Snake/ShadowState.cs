using UnityEngine;

public class ShadowState
{
    public Vector3 Position { get; }
    public Vector3 Rotation { get; }

    public ShadowState(Transform reference)
    {
        Position = reference.position;
        Rotation = reference.localEulerAngles;
    }
}
