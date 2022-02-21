using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HJKL_Timer : MonoBehaviour
{   
    public float TimerTime;
    public float StartTime = 3;
    public Text TimerText;
    public Text FinalScore;
    public Text Start;

    public GameObject gameCtr;
    public GameObject hero;

    public GameObject top_love;
    public GameObject bottom_love;
    public GameObject right_love;
    public GameObject left_love;

    private void Update()
    {
        if (StartTime > 0)
        {
            Start.text = System.Math.Round(StartTime).ToString();
            StartTime -= Time.deltaTime;
        }
        else if (StartTime < 0 && StartTime > -1)
        {
            StartTime -= 2;

            Start.gameObject.SetActive(false);

            gameCtr.SetActive(true);
            hero.SetActive(true);
        }
        else if (TimerTime < 0 && TimerTime > -1)
        {
            TimerTime -= 1;

            FinalScore.text = "Score: " + (hero.GetComponent<Hero>().loves_num -
            hero.GetComponent<Hero>().bads_num -
            gameCtr.GetComponent<Loves_crosses_mover>().fails_num).ToString();

            Invoke("LoadMenue", 3);
            Stop();
        }
        else if (TimerTime > -1)
        { 
            TimerText.text = ": ........" + System.Math.Round(TimerTime).ToString();
            TimerTime -= Time.deltaTime;
        }
    }

    private void Stop()
    {
        Destroy(bottom_love);
        Destroy(top_love);
        Destroy(right_love);
        Destroy(left_love);
        Destroy(gameCtr);
        Destroy(hero);
    }

    void LoadMenue()
    {
        GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>().MenuOrBoard();
    }
}
