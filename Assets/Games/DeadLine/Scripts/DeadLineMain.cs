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

    private Vector2 StartPosition1;
    private Vector2 StartPosition2;

    void Start()
    {
        StartPosition1 = Player1.transform.position;
        StartPosition2 = Player2.transform.position;
    }

    void Update()
    {
        if (Player1.GetComponent<PlayerMove1>().Death || Player2.GetComponent<PlayerMove2>().Death)
        {
            Invoke("Restart", 2);
            Player1.GetComponent<PlayerMove1>().Death = false;
            Player2.GetComponent<PlayerMove2>().Death = false;
        }
        else if (!TimerForStart.active && !Player1.active && !Player2.active)
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
