using UnityEngine;
using UnityEngine.UI;

public class CoinPick : MonoBehaviour
{
    public Text Score;
    private int score;

    public AudioSource pick; 
    public AudioSource BonusChest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            pick.Play();
            score += 1;
            Score.text = score.ToString();
        }
        if (collision.gameObject.tag == "BonusChest")
        {
            Destroy(collision.gameObject);
            BonusChest.Play();
            score += 50;
            Score.text = score.ToString();
        }
    }
}
