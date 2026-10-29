using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

        public TMP_Text timeText;
        float timeLeft = 180;
        bool isPlaying = false;

    public void Start()
    {
        timeLeft = 180;
        isPlaying = true;
    }

    void Update()
    {
        if (isPlaying)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                isPlaying = false;
            }

            timeText.text = "Timer: " + Mathf.CeilToInt(timeLeft).ToString();
        }
    }
}
