using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] TMP_Text scoreText;

    void Update()
    {
        scoreText.text = scoreKeeper.Score.ToString();
    }
}
