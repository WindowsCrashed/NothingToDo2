using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadMovement : MonoBehaviour
{
    [SerializeField] Transform movePoint;
    [SerializeField] float moveSpeed;

    [SerializeField] SpriteController headSpriteController;
    [SerializeField] BodyMovement body;

    Vector2 moveInput;
    HashSet<float> validInput = new() { 0, 1, -1 };

    Axis currentAxis;
    Axis previousAxis;

    bool isTimerOn;
    float timer;

    void Start()
    {
        Axis currentAxis = Axis.Horizontal;
        Axis previousAxis = currentAxis;
        
        isTimerOn = true;    
    }

    void Update()
    {
        Timer();
        MoveHead();
    }

    void MoveHead()
    {
        if (!isTimerOn)
        {
            body.MoveBody();
            MoveToMovePoint();
        }
    }

    void OnMove(InputValue value)
    {
        if (isTimerOn)
        {
            if (validInput.Contains(value.Get<Vector2>().x) && validInput.Contains(value.Get<Vector2>().y))
            {
                moveInput = value.Get<Vector2>();
                
                SetAxis(moveInput);

                if (currentAxis != previousAxis)
                {
                    if (moveInput.x != 0 || moveInput.y != 0)
                    {
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
        isTimerOn = true;
    }

    void ChangeMovePointPosition(Vector2 moveInput)
    {
        movePoint.position = transform.position + new Vector3(moveInput.x, moveInput.y, movePoint.position.z);
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

    void Timer()
    {
        if (isTimerOn)
        {
            timer += Time.deltaTime;

            if (timer >= (10 / moveSpeed))
            {
                isTimerOn = false;
                timer = 0;
            }
        }
    }
}
