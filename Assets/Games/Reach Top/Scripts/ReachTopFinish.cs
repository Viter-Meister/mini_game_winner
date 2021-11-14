using UnityEngine;
using UnityEngine.UI;

public class ReachTopFinish : MonoBehaviour
{
    public GameControllerBlue playerBlue;
    public GameControllerRed playerRed;

    private bool IsWin;

    public Text Winner;

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
            Winner.text = "Blue won!";
        else
            Winner.text = "Red won!";
    }
}
