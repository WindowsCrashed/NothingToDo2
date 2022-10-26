using UnityEngine;

public class UIControls : MonoBehaviour
{
    public KeyCode Key { get; private set; }

    void Update()
    {
        //Key = KeyCode.None;
    }

    public void GetInput(int index)
    {
        if (index == 0)
        {
            Key = KeyCode.UpArrow;
        }
        else if (index == 1)
        {
            Key = KeyCode.DownArrow;
        }
        else if (index == 2)
        {
            Key = KeyCode.LeftArrow;
        }
        else if (index == 3)
        {
            Key = KeyCode.RightArrow;
        }
        else if (index == 4)
        {
            Key = KeyCode.A;
        }
    }
}
