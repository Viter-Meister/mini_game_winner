using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public GameControllerBlue playerBlue;
    public GameControllerRed playerRed;

    private bool IsWin;

    public Text Winner;

    void Update()
    {
        if (!IsWin && playerBlue.newY == 6)
        {
            IsWin = true;
            playerBlue.StopAllCoroutines();
            playerRed.StopAllCoroutines();
            Destroy(playerBlue.BoxeToPlace.gameObject);
            Destroy(playerRed.BoxeToPlace.gameObject);
            Winner.text = "Blue won!";
        }
        if (!IsWin && playerRed.newY == 6)
        {
            IsWin = true;
            playerBlue.StopAllCoroutines();
            playerRed.StopAllCoroutines();
            Destroy(playerBlue.BoxeToPlace.gameObject);
            Destroy(playerRed.BoxeToPlace.gameObject);
            Winner.text = "Red won!";
        }
    }
}
