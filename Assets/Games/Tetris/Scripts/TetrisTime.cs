using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisTime : MonoBehaviour
{
    public TetrisMain main;
    public float time;

    private TextMesh Text;
    private float firstTime;

    void Start()
    {
        firstTime = Time.time;
        Text = GetComponent<TextMesh>();
    }

    void Update()
    {
        int nowTime = (int)Mathf.Round(time - (Time.time - firstTime));
        if (nowTime < 0)
        {
            main.GameIsOver();
            return;
        }

        int min = nowTime / 60;
        int sec = nowTime % 60;
        Text.text =  (min / 10 == 0 ? "0" : "") + min.ToString() + ":" + 
            (sec / 10 == 0 ? "0" : "") + sec.ToString();
    }
}
