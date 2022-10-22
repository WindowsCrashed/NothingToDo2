using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] HeadMovement head;
    [SerializeField] BodyMovement bodyPart;
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
        if (Input.GetKeyDown(KeyCode.Z)) SpawnBodyPart();

        Timer();
        MoveSnake();
    }

    void MoveSnake()
    {
        if (!IsTimerOn)
        {
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

    void SpawnBodyPart()
    {
        ISnake spawnParent;

        if (bodyParts == null || bodyParts.Count == 0)
        {
            spawnParent = head;
        } else
        {
            spawnParent = bodyParts[^1];
        }

        BodyMovement newBodyPart = Instantiate(bodyPart, spawnParent.GetSpawnPoint().position, Quaternion.identity);
        newBodyPart.SetParentPosition(spawnParent.GetTransform());
        newBodyPart.gameObject.transform.SetParent(transform);
        bodyParts.Add(newBodyPart);
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
