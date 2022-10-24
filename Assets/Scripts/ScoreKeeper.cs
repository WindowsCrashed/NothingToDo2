using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int pointsPerTarget;

    public int Score { get; private set; }
    public int HighScore { get; private set; }

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType<ScoreKeeper>().Length;

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncreaseScore()
    {
        Score += pointsPerTarget;
        Score = Mathf.Clamp(Score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void SetHighScore()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
        }
    }
}
