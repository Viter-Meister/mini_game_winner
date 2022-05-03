using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootEmUp_Stats : MonoBehaviour
{
    public UnityEngine.UI.Text bonuses;
    public UnityEngine.UI.Text kills;
    public UnityEngine.UI.Text life;
    public UnityEngine.UI.Text distance;

    private string[] bonusesArray = new string[3];
    private int killsCount = 0;
    public  int lifeCount = 3;
    private int distancePercent = 0;

    public AudioSource kill;

    public float minutes = 1.0f;

    void Start()
    {
        bonuses.text   = "Bonuses:  —";
        kills.text     = "Kills: 0";
        life.text      = "Life: " + lifeCount;
        distance.text  = "0%";

        StartCoroutine(DistanceWaiter(minutes*60/100));
    }

    public void AddBonus(string newBonus)
    {
        bonusesArray.Append(newBonus);
        bonuses.text = "Bonuses: ";
        foreach (string bonus in bonusesArray) {
            bonuses.text += bonus;
        }
    }

    public void AddKill()
    {
        killsCount++;
        kill.Play();
        kills.text = "Kills: " + killsCount;
    }

    public void RemoveLife()
    {
        if (lifeCount == 1)
            GameIsOver();
        lifeCount--;
        life.text = "Life: " + lifeCount;
    }

    public void IncDistance()
    {
        distancePercent++;
        if (distancePercent < 100)
            distance.text = distancePercent + "%";
        else {
            distance.text = "100%";
            GameIsOver();
        }
    }

    IEnumerator DistanceWaiter(float time)
    {
        yield return new WaitForSeconds(time);
        IncDistance();
        StartCoroutine(DistanceWaiter(time));
    }

    public void GameIsOver()
    {
        BasicValues bv = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();

        int x = distancePercent;

        if (x >= 100)
            bv.ChooseBonus(6);

        bv.MenuOrBoard();
    }
}
