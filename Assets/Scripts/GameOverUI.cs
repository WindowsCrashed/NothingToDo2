using System.Collections;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TMP_Text scoreLabelText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreLabelText;
    [SerializeField] TMP_Text highScoreText;

    [Header("Buttons")]
    [SerializeField] GameObject buttons;

    [Header("Delay")]
    [SerializeField] float delay = 0.5f;

    ScoreKeeper scoreKeeper;
    BlinkEffect blinkEffect;
    CountEffect countEffect;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        blinkEffect = GetComponent<BlinkEffect>();
        countEffect = GetComponent<CountEffect>();
    }

    void Start()
    {
        scoreText.text = scoreKeeper.Score.ToString();
        highScoreText.text = scoreKeeper.HighScore.ToString();

        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSecondsRealtime(delay + 0.5f);

        scoreLabelText.alpha = 1;

        yield return new WaitForSecondsRealtime(delay);

        scoreText.alpha = 1;

        yield return StartCoroutine(countEffect.CountUpEffect(scoreText, scoreKeeper.Score));

        yield return new WaitForSecondsRealtime(delay);

        highScoreLabelText.alpha = 1;

        yield return new WaitForSecondsRealtime(delay);

        highScoreText.alpha = 1;

        if (scoreKeeper.IsNewHighScore)
        {
            FindObjectOfType<AudioManager>().PlayClip("NewHighScore");
            yield return StartCoroutine(blinkEffect.Blink(highScoreText));
        }

        yield return new WaitForSecondsRealtime(delay);

        buttons.SetActive(true);
    }
}
