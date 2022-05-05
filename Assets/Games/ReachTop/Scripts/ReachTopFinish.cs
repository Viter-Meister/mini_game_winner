using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReachTopFinish : MonoBehaviour
{
    public GameControllerBlue playerBlue;
    public GameControllerRed playerRed;

    private bool IsWin;

    public Text Winner;

    private bool isRedWin;

    void Update()
    {
        if (IsWin)
            return;
        if (playerBlue.newY < 6 && playerRed.newY < 6)
            return;

        IsWin = true;
        playerBlue.StopAllCoroutines();
        playerRed.StopAllCoroutines();
        Destroy(playerBlue.BoxeToPlace.gameObject);
        Destroy(playerRed.BoxeToPlace.gameObject);

        if (playerBlue.newY == 6)
        {
            Winner.text = "Синий выиграл!";
            isRedWin = false;
        }
        else
        {
            Winner.text = "Красный выиграл!";
            isRedWin = true;
        }

        Invoke("GameIsOver", 2);
    }

    public void GameIsOver()
    {
        BasicValues bv = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();

        if ((isRedWin && bv.isArrows) || (!isRedWin && !bv.isArrows))
            bv.ChooseBonus(6);

        bv.MenuOrBoard();
    }
}