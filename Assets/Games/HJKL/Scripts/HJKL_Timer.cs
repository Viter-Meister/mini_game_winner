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

    private int score = 0;

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

            Hero h = hero.GetComponent<Hero>();

            score = h.loves_num - h.bads_num - gameCtr.GetComponent<Loves_crosses_mover>().fails_num;

            FinalScore.text = "Score: " + score.ToString();

            Invoke("GameIsOver", 2);
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

    public void GameIsOver()
    {
        BasicValues bv = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();

        int x = score;

        if (x > 20)
        {
            if (x <= 25)
                bv.ChooseBonus(1);
            if (x <= 30)
                bv.ChooseBonus(2);
            if (x <= 33)
                bv.ChooseBonus(3);
            if (x <= 35)
                bv.ChooseBonus(4);
            if (x <= 40 || bv.playersCount == 1)
                bv.ChooseBonus(5);
            else
                bv.ChooseBonus(6);
        }

        bv.MenuOrBoard();
    }
}
