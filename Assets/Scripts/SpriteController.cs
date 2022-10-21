using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    void ResetTransform()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void TurnSprite(Vector2 input)
    {
        ResetTransform();

        if (input.x == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (input.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (input.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
