using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] HeadMovement head;
    [SerializeField] float moveSpeed;

    //HashSet<BodyMovement> bodyParts;
    [SerializeField] List<BodyMovement> bodyParts;

    float timer;

    public bool IsTimerOn { get; private set; }

    void Awake()
    {
        //bodyParts = new();
        IsTimerOn = true;       
    }

    void Start()
    {
        //bodyParts.Add(FindObjectOfType<BodyMovement>());
    }

    void Update()
    {
        Timer();
        MoveSnake();
    }

    void MoveSnake()
    {
        if (!IsTimerOn)
        {
            //MoveBodyMovePoints();
            head.MoveHead();
            MoveBody();
            IsTimerOn = true;
        }
    }

    void MoveBody()
    {
        foreach (BodyMovement bodyPart in bodyParts)
        {
            bodyPart.MoveBody();
        }
    }

    void MoveBodyMovePoints()
    {
        foreach (BodyMovement bodyPart in bodyParts)
        {
            //bodyPart.ChangeMovePointPosition();
        }
    }

    void Timer()
    {
        if (IsTimerOn)
        {
            timer += Time.deltaTime;

            if (timer >= (10 / moveSpeed))
            {
                IsTimerOn = false;
                timer = 0;
            }
        }
    }
}
