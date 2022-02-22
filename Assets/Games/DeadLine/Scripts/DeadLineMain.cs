using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineMain : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public GameObject Trail1;
    public GameObject Trail2;

    public GameObject TimerForStart;

    private int point1 = 0;
    private int point2 = 0;

    public GameObject[] ScoreRight = new GameObject[3];
    public GameObject[] ScoreLeft = new GameObject[3];

    public GameObject RedWin;
    public GameObject BlueWin;

    private Vector2 StartPosition1;
    private Vector2 StartPosition2;

    void Start()
    {
        StartPosition1 = Player1.transform.position;
        StartPosition2 = Player2.transform.position;
    }

    void Update()
    {
        if (Player1.GetComponent<PlayerMove>().Death || Player2.GetComponent<PlayerMove>().Death)
        {
            if (Player2.GetComponent<PlayerMove>().Death && (point1 < 3) && (point2 < 3))
            {
                point1 += 1;
                ScoreRight[point1 - 1].SetActive(true);
            }
            if (Player1.GetComponent<PlayerMove>().Death && (point2 < 3) && (point1 < 3))
            {
                point2 += 1;
                ScoreLeft[point2 - 1].SetActive(true);
            }
            if ((point1 == 3) || (point2 == 3))
            {
                if (point1 == 3)
                {
                    RedWin.SetActive(true);
                }
                else
                {
                    BlueWin.SetActive(true);
                }

                Player1.SetActive(false);
                Player2.SetActive(false);

                gameObject.SetActive(false);
            }
            Invoke("Restart", 2);
            Player1.GetComponent<PlayerMove>().Death = false;
            Player2.GetComponent<PlayerMove>().Death = false;
        }
        else if (!TimerForStart.activeSelf && !Player1.activeSelf && !Player2.activeSelf)
        {
            Player1.SetActive(true);
            Player2.SetActive(true);

            Trail1.SetActive(true);
            Trail2.SetActive(true);
        }
    }

    private void Restart()
    {
        ClearTrail();

        Player1.SetActive(false);
        Player2.SetActive(false);

        Player1.transform.position = StartPosition1;
        Player2.transform.position = StartPosition2;
    }

    private void ClearTrail()
    {
        Trail1.GetComponent<LineRenderer>().positionCount = 0;
        Trail1.GetComponent<DrawTrail>().pointsList.Clear();

        Trail2.GetComponent<LineRenderer>().positionCount = 0;
        Trail2.GetComponent<DrawTrail>().pointsList.Clear();

        Trail1.GetComponent<DrawTrail>().TrailLength = 0;
        Trail2.GetComponent<DrawTrail>().TrailLength = 0;
    }
}
