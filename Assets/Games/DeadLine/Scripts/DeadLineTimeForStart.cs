using UnityEngine.UI;
using UnityEngine;

public class DeadLineTimeForStart : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private float TimeForStart = 3;
    public Text TextForStart;

    void Update()
    {
        if (TimeForStart > 0)
        {
            TimeForStart -= Time.deltaTime;
            TextForStart.text = Mathf.Round(TimeForStart).ToString();
        }
        else
        {
            player1.SetActive(true);
            player2.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
