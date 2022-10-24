using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject target;

    readonly int[] horizontalRange = new[] { -10, 10 };
    readonly int[] verticalRange = new[] { -5, 7 };

    void SpawnTarget()
    {
        Instantiate(target, transform.position, Quaternion.identity);
    }

    public void MoveToRandomLocation()
    {
        int xPos = Random.Range(horizontalRange[0], horizontalRange[1] + 1);
        int yPos = Random.Range(verticalRange[0], verticalRange[1] + 1);

        transform.position = new Vector2(xPos, yPos);
    }

    public void SpawnAtRandomLocation()
    {
        MoveToRandomLocation();

        if (Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y),
            new Vector2(transform.localScale.x, transform.localScale.y), 0).Length != 0)
        {
            SpawnAtRandomLocation();
            return;
        }

        SpawnTarget();
    }
}
