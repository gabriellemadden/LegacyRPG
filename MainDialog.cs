using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainDialog : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float displayTime = 3.0f;
    float timerDisplay;
    bool thinking;

    void Update()
    {
        if (thinking)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                gameObject.SetActive(false);
                thinking = false;
            }
        }
    }

    public void SendThought(string thought)
    {
        text.SetText(thought);
        thinking = true;
        timerDisplay = displayTime;
        gameObject.SetActive(true);
    }
}
