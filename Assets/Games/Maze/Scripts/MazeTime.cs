using UnityEngine;
using UnityEngine.UI;

public class MazeTime : MonoBehaviour
{
    public GameObject player;

    public Text TimerForStart;
    public Text Time;

    private float timerforstart = 3;
    private float time = 60;

    void Update()
    {
        if (timerforstart > 0)
        {
            timerforstart -= UnityEngine.Time.deltaTime;
            TimerForStart.text = Mathf.Round(timerforstart).ToString();
        }
        else if (time > 0)
        {
            TimerForStart.gameObject.SetActive(false);
            player.SetActive(true);
            time -= UnityEngine.Time.deltaTime;
            Time.text = Mathf.Round(time).ToString();
        }
        else
        {
            player.SetActive(false);
            Invoke("LoadMenue", 3);
        }
    }

    void LoadMenue()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenue");
    }
}
