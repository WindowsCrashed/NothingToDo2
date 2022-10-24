using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CountEffect : MonoBehaviour
{
    [SerializeField] int incrementValue = 5;

    bool wasSkipped;

    void OnTouchScreen(InputValue value)
    {
        Skip();
    }

    void Skip()
    {
        wasSkipped = true;
    }

    public IEnumerator CountUpEffect(TMP_Text text, int value)
    {
        int count = 0;
        //AudioManager audioManager = FindObjectOfType<AudioManager>();

        if (value != 0)
        {
            //audioManager.PlayClip("Count");
        }

        while (count <= value)
        {
            if (wasSkipped)
            {
                text.text = value.ToString();
                break;
            }

            text.text = count.ToString();
            count += incrementValue;
            Mathf.Clamp(count, 0, value);

            yield return new WaitForEndOfFrame();
        }

        if (value != 0)
        {
            //audioManager.StopClip("Count");
            //audioManager.PlayClip("CountCoda");
        }
    }
}
