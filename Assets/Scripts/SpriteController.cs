using UnityEngine;

public class SpriteController : MonoBehaviour
{
    void ResetTransform()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void FlipSprite(Vector2 input)
    {
        ResetTransform();

        if (input.x == 1)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
}
