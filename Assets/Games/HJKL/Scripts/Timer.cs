using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   
    public float TimerTime;

    public Text TimerText;

    public Text FinalScore;

    public Loves_crosses_mover lcm;

    public Hero hero;

    private void Update()
    {
        if (TimerTime < 0)
        {
            SceneManager.LoadScene("MainMenu");
            //Stop();

            //StartCoroutine(Wait());
        }
        else
        {
            TimerText.text = ": ........" + System.Math.Round(TimerTime).ToString();
            TimerTime -= Time.deltaTime;
        }
    }

    private void Stop()
    {
        /*Destroy(GameObject.Find("right_LOVE"));
        Destroy(GameObject.Find("left_LOVE"));
        Destroy(GameObject.Find("right_LOVE_1"));
        Destroy(GameObject.Find("left_LOVE_1"));
        Destroy(GameObject.Find("right_LOVE_2"));
        Destroy(GameObject.Find("left_LOVE_2"));
        Destroy(GameObject.Find("right_CROSS"));
        Destroy(GameObject.Find("left_CROSS"));

        Destroy(GameObject.Find("top_LOVE"));
        Destroy(GameObject.Find("bottom_LOVE"));
        Destroy(GameObject.Find("top_LOVE_1"));
        Destroy(GameObject.Find("bottom_LOVE_1"));
        Destroy(GameObject.Find("top_LOVE_2"));
        Destroy(GameObject.Find("bottom_LOVE_2"));
        Destroy(GameObject.Find("top_CROSS"));
        Destroy(GameObject.Find("bottom_CROSS"));

        Destroy(lcm.gameObject);
        Destroy(hero.gameObject);*/

        FinalScore.text = "Score: " + (hero.loves_num - hero.bads_num - lcm.fails_num).ToString();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
