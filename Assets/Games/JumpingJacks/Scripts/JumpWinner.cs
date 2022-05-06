using TMPro;
using UnityEngine;

public class JumpWinner : MonoBehaviour
{
    public GameObject playerLeft;
    public GameObject playerRight;
    public GameObject cm;

    private int scoreLeft;
    private int scoreRight;

    public TMP_Text WinnerText;

    private bool isEnd = false;

    void Update()
    {
        scoreLeft = playerLeft.GetComponent<LeftPlayer>().score;
        scoreRight = playerRight.GetComponent<RightPlayer>().score;
        if (!isEnd && !playerLeft.activeSelf && !playerRight.activeSelf)
        {
            isEnd = true;
            cm.SetActive(true);
            if (scoreLeft > scoreRight)
                WinnerText.text = "Игрок слева выиграл!";
            else if (scoreLeft < scoreRight)
                WinnerText.text = "Игрок справа выиграл!";
            else
                WinnerText.text = "Ничья";

            Invoke("GameIsOver", 2);
        }
    }

    public void GameIsOver()
    {
        BasicValues bv = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();

        if ((scoreLeft < scoreRight && bv.isArrows) ||
            (scoreLeft > scoreRight && !bv.isArrows))
            bv.ChooseBonus(6);

        bv.MenuOrBoard();
    }
}
