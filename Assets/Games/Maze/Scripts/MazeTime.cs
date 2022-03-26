using UnityEngine;
using UnityEngine.UI;

public class MazeTime : MonoBehaviour
{
    public GameObject player;

    public Text TimerForStart;
    public Text Time;

    private float timerforstart = 3;
    private float time = 60;

    void Update()
    {
        if (timerforstart > 0)
        {
            timerforstart -= UnityEngine.Time.deltaTime;
            TimerForStart.text = Mathf.Round(timerforstart).ToString();
        }
        else if (time > 0)
        {
            TimerForStart.gameObject.SetActive(false);
            player.SetActive(true);
            time -= UnityEngine.Time.deltaTime;
            Time.text = Mathf.Round(time).ToString();
        }
        else
            Invoke("GameIsOver", 1);
    }

    public void GameIsOver()
    {
        BasicValues bv = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();

        int x = int.Parse(GameObject.Find("ScoreInt").GetComponent<Text>().text);

        if (x > 65)
        {
            if (x <= 70)
                bv.ChooseBonus(1);
            if (x <= 79)
                bv.ChooseBonus(2);
            if (x <= 99)
                bv.ChooseBonus(3);
            if (x <= 109)
                bv.ChooseBonus(4);
            if (x <= 129 || bv.playersCount == 1)
                bv.ChooseBonus(5);
            else
                bv.ChooseBonus(6);
        }

        bv.MenuOrBoard();
    }
}
