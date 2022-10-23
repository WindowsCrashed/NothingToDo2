using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] HeadMovement head;
    [SerializeField] BodyMovement bodyPart;
    [SerializeField] SpawnerController spawn;
    [SerializeField] float moveSpeed;    

    readonly LinkedList<BodyMovement> bodyParts = new();

    float timer;

    public bool IsTimerOn { get; private set; }   

    void Awake()
    {
        IsTimerOn = true;
    }

    void Start()
    {
        SpawnTarget();  
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
            if (head.IsFacingObstacle)
            {
                // Die
                Destroy(gameObject);
            }

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

    public void SpawnBodyPart()
    {
        ISnake spawnParent;

        if (bodyParts == null || bodyParts.Count == 0)
        {
            spawnParent = head;
        }
        else
        {
            spawnParent = bodyParts.Last.Value;
        }

        BodyMovement newBodyPart = Instantiate(bodyPart,
            spawnParent.GetSpawnPoint().position, spawnParent.GetTransform().rotation);
        newBodyPart.SetParentTransform(spawnParent.GetTransform());
        newBodyPart.gameObject.transform.SetParent(transform);
        bodyParts.AddLast(newBodyPart);
    }

    public void SpawnTarget()
    {
        spawn.SpawnAtRandomLocation();
    }
}
