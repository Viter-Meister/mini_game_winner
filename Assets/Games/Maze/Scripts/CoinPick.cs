using UnityEngine;
using UnityEngine.UI;

public class CoinPick : MonoBehaviour
{
    public Text Score;
    private int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            score += 1;
            Score.text = score.ToString();
        }
    }
}
