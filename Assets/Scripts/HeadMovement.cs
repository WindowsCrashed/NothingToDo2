using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadMovement : MonoBehaviour
{
    [SerializeField] Transform movePoint;
    [SerializeField] float moveSpeed;

    [SerializeField] SpriteController headSpriteController;

    //PlayerAnimation anim;

    Vector2 moveInput;
    bool isMoving;

    HashSet<float> validInput = new() { 0, 1, -1 };

    //FacingDirection facingDirection;
    //FacingDirection previousFacingDirection;

    bool isTimerOn;
    float timer;

    void Start()
    {
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
            MoveToMovePoint();
        }

        //ChangeFacePointPosition(moveInput);
        //SetFacingDirection();
    }

    void OnMove(InputValue value)
    {
        if (isTimerOn)
        {
            if (validInput.Contains(value.Get<Vector2>().x) && validInput.Contains(value.Get<Vector2>().y))
            {
                moveInput = value.Get<Vector2>();

                if (moveInput.x != 0 || moveInput.y != 0)
                {
                    ChangeMovePointPosition(moveInput);
                    headSpriteController.TurnSprite(moveInput);
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
