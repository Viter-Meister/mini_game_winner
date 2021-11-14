using UnityEngine;
using UnityEngine.UI;
using System;

public class ReachTopTimer : MonoBehaviour
{
    public float TimerTime = 3;
    public Text TimerText;

    void Update()
    {
        if (TimerTime < 0.5f)
            Destroy(TimerText.gameObject);
        else
        {
            TimerText.text = Math.Round(TimerTime).ToString();
            TimerTime -= Time.deltaTime;
        }
    }
}
