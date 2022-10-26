using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    IEnumerator ProcessDeath()
    {
        HeadMovement head = FindObjectOfType<HeadMovement>();

        yield return StartCoroutine(head.GetComponent<BlinkEffect>()
            .Blink(head.GetComponentInChildren<SpriteRenderer>()));

        LoadGameOver();
    }

    public void Die()
    {
        StartCoroutine(ProcessDeath());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        scoreKeeper.SetHighScore();
        SceneManager.LoadScene("GameOver");
    }
}
