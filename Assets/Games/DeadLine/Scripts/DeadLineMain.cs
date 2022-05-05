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
    private Quaternion StartRotation1;
    private Vector2 StartPosition2;
    private Quaternion StartRotation2;

    private bool isRightWin;

    void Start()
    {
        StartPosition1 = Player1.transform.position;
        StartRotation1 = Player1.transform.rotation;

        StartPosition2 = Player2.transform.position;
        StartRotation2 = Player2.transform.rotation;
    }

    void Update()
    {
        if ((point1 == 3) || (point2 == 3))
        {
            if (point1 == 3)
            {
                isRightWin = true;
                RedWin.SetActive(true);
            }
            else
            {
                isRightWin = false;
                BlueWin.SetActive(true);
            }

            Player1.SetActive(false);
            Player2.SetActive(false);

            gameObject.SetActive(false);
        }
        else
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

                    Invoke("GameIsOver", 2);
                }
                Invoke("Restart", 3);
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
    }

    private void Restart()
    {
        ClearTrail();
        ClearCollider();

        Player1.SetActive(false);
        Player2.SetActive(false);

        Player1.transform.position = StartPosition1;
        Player2.transform.position = StartPosition2;
        Player1.transform.rotation = StartRotation1;
        Player2.transform.rotation = StartRotation2;
    }

    public void GameIsOver()
    {
        BasicValues bv = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();

        if ((isRightWin && bv.isArrows) || (!isRightWin && !bv.isArrows))
            bv.ChooseBonus(6);

        bv.MenuOrBoard();
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

    private void ClearCollider()
    {
        Trail1.GetComponent<DrawTrail>().collider.Reset();
        Trail1.GetComponent<DrawTrail>().collider.isTrigger = true;
        Trail2.GetComponent<DrawTrail>().collider.Reset();
        Trail2.GetComponent<DrawTrail>().collider.isTrigger = true;
    }
}
