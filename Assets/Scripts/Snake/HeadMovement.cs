using UnityEngine;
using UnityEngine.InputSystem;

public class HeadMovement : MonoBehaviour, ISnake
{
    [SerializeField] Transform movePoint;
    [SerializeField] Transform spawnPoint;

    [SerializeField] SnakeController snake;
    [SerializeField] SpriteController headSpriteController;
    [SerializeField] UIControls controls;

    Vector2 moveInput;

    Axis currentAxis;
    Axis previousAxis;

    bool hasPressedKey;

    public bool IsFacingObstacle { get; set; }

    void Start()
    {
        currentAxis = Axis.Horizontal;
        previousAxis = currentAxis;          
    }

    void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers(LayerMask.GetMask("Head")) && collision.CompareTag("Target"))
        {
            Eat(collision);
        }
    }

    void Move()
    {
        if (snake.IsTimerOn && !hasPressedKey)
        {
            moveInput = DetectKey();

            if (moveInput.x != 0 || moveInput.y != 0)
            {
                SetAxis(moveInput);

                if (currentAxis != previousAxis)
                {                   
                    hasPressedKey = true;
                    ChangeMovePointPosition(moveInput);
                }
            }
        }
    }

    void Eat(Collider2D target)
    {
        snake.SpawnBodyPart();
        Destroy(target.gameObject);
        FindObjectOfType<ScoreKeeper>().IncreaseScore();
        snake.SpawnTarget();
    }

    
    Vector2 DetectKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return new Vector2(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return new Vector2(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return new Vector2(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return new Vector2(1, 0);
        }

        return new Vector2(0, 0);
    }
    
    /*
    Vector2 DetectKey()
    {
        if (controls.Key == KeyCode.UpArrow)
        {
            return new Vector2(0, 1);
        }
        else if (controls.Key == KeyCode.DownArrow)
        {
            return new Vector2(0, -1);
        }
        else if (controls.Key == KeyCode.LeftArrow)
        {
            return new Vector2(-1, 0);
        }
        else if (controls.Key == KeyCode.RightArrow)
        {
            return new Vector2(1, 0);
        }

        return new Vector2(0, 0);
    }
    */

    public Quaternion SetRotation(Vector2 input)
    {
        if (input.x == 1)
        {
            return Quaternion.Euler(0, 0, -180);
        }
        else if (input.y == -1)
        {
            return Quaternion.Euler(0, 0, 90);
        }
        else if (input.y == 1)
        {
            return Quaternion.Euler(0, 0, -90);
        }
        else if (input.x == -1)
        {
            return Quaternion.Euler(0, 0, 0);
        }

        return transform.rotation;
    }
    
    void MoveToMovePoint()
    {
        if (hasPressedKey)
        {
            headSpriteController.FlipSprite(moveInput);
        }
        
        transform.SetPositionAndRotation(movePoint.position, SetRotation(moveInput));
        ResetMovePoint();
    }

    void ChangeMovePointPosition(Vector2 moveInput)
    {
        movePoint.position = transform.position + new Vector3(moveInput.x, moveInput.y, movePoint.position.z);
    }

    void ResetMovePoint()
    {
        movePoint.localPosition = new Vector3(-1, 0, 0);
    }

    void SetAxis(Vector2 moveInput)
    {
        previousAxis = currentAxis;

        if (moveInput.x != 0)
        {
            currentAxis = Axis.Horizontal;
        }
        else if (moveInput.y != 0)
        {
            currentAxis = Axis.Vertical;
        }
    }

    public void MoveHead()
    {
        MoveToMovePoint();
        hasPressedKey = false;
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
