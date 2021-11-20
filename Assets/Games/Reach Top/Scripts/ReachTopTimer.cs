using UnityEngine;
using UnityEngine.UI;
using System;

public class ReachTopTimer : MonoBehaviour
{
    public float TimerTime = 3;
    public Text TimerText;
    public Text Space;
    public Text Enter;

    void Update()
    {
        if (TimerTime < 0.5f)
        {
            Destroy(TimerText.gameObject);
            Destroy(Space.gameObject);
            Destroy(Enter.gameObject);
        }
        else
        {
            TimerText.text = Math.Round(TimerTime).ToString();
            TimerTime -= Time.deltaTime;
        }
    }
}
