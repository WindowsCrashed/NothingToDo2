using System.Collections;
using UnityEngine;
using TMPro;

public class BlinkEffect : MonoBehaviour
{
    [SerializeField] float interval;
    [SerializeField] int duration;
    [SerializeField] bool endless;

    public IEnumerator Blink(TMP_Text text)
    {
        if (endless)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(interval);
                text.alpha = Mathf.Abs(text.alpha - 1);
            }
        }
        else
        {
            duration *= 2;

            for (int i = 0; i < duration; i++)
            {
                yield return new WaitForSecondsRealtime(interval);
                text.alpha = Mathf.Abs(text.alpha - 1);
            }
        }
    }

    public IEnumerator Blink(SpriteRenderer sprite)
    {
        if (endless)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(interval);
                sprite.color = new Color(0, 0, 0, Mathf.Abs(sprite.color.a - 1));
            }
        }
        else
        {
            for (int i = 0; i < duration; i++)
            {
                sprite.color -= new Color(0, 0, 0, 1);
                yield return new WaitForSecondsRealtime(interval);
                sprite.color += new Color(0, 0, 0, 1);
                yield return new WaitForSecondsRealtime(interval);               
            }
        }
    }
}
