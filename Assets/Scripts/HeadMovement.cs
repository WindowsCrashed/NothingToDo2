using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadMovement : MonoBehaviour, ISnake
{
    [SerializeField] Transform movePoint;
    [SerializeField] Transform spawnPoint;

    [SerializeField] SpriteController headSpriteController;

    Vector2 moveInput;
    readonly HashSet<float> validInput = new() { 0, 1, -1 };

    Axis currentAxis;
    Axis previousAxis;

    bool hasPressedKey;

    SnakeController snake;

    public Transform SpawnPoint => spawnPoint;

    void Awake()
    {
        snake = GetComponentInParent<SnakeController>();
    }

    void Start()
    {
        Axis currentAxis = Axis.Horizontal;
        Axis previousAxis = currentAxis;          
    }

    void Update()
    {
        //MoveHead();
    }

    void OnMove(InputValue value)
    {
        if (snake.IsTimerOn && !hasPressedKey)
        {
            if (validInput.Contains(value.Get<Vector2>().x) && validInput.Contains(value.Get<Vector2>().y))
            {
                moveInput = value.Get<Vector2>();
                
                SetAxis(moveInput);

                if (currentAxis != previousAxis)
                {
                    if (moveInput.x != 0 || moveInput.y != 0)
                    {
                        hasPressedKey = true;
                        ChangeMovePointPosition(moveInput);
                        headSpriteController.TurnSprite(moveInput);
                    }
                }            
            }
        }
    }

    void MoveToMovePoint()
    {
        transform.position = movePoint.position;
    }

    void ChangeMovePointPosition(Vector2 moveInput)
    {
        movePoint.position = transform.position + new Vector3(moveInput.x, moveInput.y, movePoint.position.z);
        ChangeSpawnPointPosition(moveInput);
    }

    void ChangeSpawnPointPosition(Vector2 moveInput)
    {
        spawnPoint.position = transform.position - new Vector3(moveInput.x, moveInput.y, movePoint.position.z);
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
