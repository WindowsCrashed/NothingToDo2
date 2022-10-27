using System.Collections;
using UnityEngine;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TMP_Text superTitleText;
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text twoText;
    [SerializeField] TMP_Text highScoreLabelText;
    [SerializeField] TMP_Text highScoreText;

    [Header("Buttons")]
    [SerializeField] GameObject playButton;

    [Header("Delay")]
    [SerializeField] float delay = 0.5f;

    ScoreKeeper scoreKeeper;
    BlinkEffect blinkEffect;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        blinkEffect = GetComponent<BlinkEffect>();
    }

    void Start()
    {
        highScoreText.text = scoreKeeper.HighScore.ToString();

        FindObjectOfType<AudioManager>().PlayClip("Fugue");

        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSecondsRealtime(delay + 0.72f);

        superTitleText.alpha = 1;

        yield return new WaitForSecondsRealtime(delay + 1.1f);

        titleText.alpha = 1;

        yield return new WaitForSecondsRealtime(delay + 0.6f);

        twoText.alpha = 1;

        playButton.SetActive(true);
        StartCoroutine(blinkEffect.Blink(playButton.GetComponentInChildren<TMP_Text>()));
        highScoreLabelText.alpha = 1;
        highScoreText.alpha = 1;
    }
}
