using UnityEngine;

public class MovePointController : MonoBehaviour
{
    [SerializeField] HeadMovement head;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers(LayerMask.GetMask("MovePoint")) &&
            (collision.CompareTag("Border") || collision.CompareTag("Body")))
        {
            head.IsFacingObstacle = true;
        } 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        head.IsFacingObstacle = false;
    }
}
