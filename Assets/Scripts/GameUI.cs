using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{   
    [SerializeField] TMP_Text scoreText;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.Score.ToString();
    }
}
