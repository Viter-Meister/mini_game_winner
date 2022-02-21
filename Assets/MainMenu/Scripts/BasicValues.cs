using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicValues : MonoBehaviour
{
    public bool isGame;
    public int playersCount;
    public int[] playersPosition;
    public int nowPlayer = 0;
    public int nowPlayer2 = 0;
    public int[] nextGame;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Reload()
    {
        for (int i = 0; i < playersPosition.Length; i++)
            playersPosition[i] = 0;
        for (int i = 0; i < nextGame.Length; i++)
            nextGame[i] = -1;
        nowPlayer = 0;
        isGame = false;
    }

    public void MenuOrBoard()
    {
        if (isGame)
            SceneManager.LoadScene("Board");
        else
            SceneManager.LoadScene("MainMenu");
    }
}
