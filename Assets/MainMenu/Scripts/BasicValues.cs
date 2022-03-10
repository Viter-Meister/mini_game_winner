using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicValues : MonoBehaviour
{
    public GameObject panelExit;
    public bool isGame;
    public int playersCount;
    public int[] playersPosition;
    public int nowPlayer;
    public bool[] nextGame;
    public int nowBonus;
    private AudioSource audioSource;
    

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        var click = GameObject.Find("Click(Clone)");
        audioSource = click.GetComponent<AudioSource>();
    }

    public void Reload()
    {
        for (int i = 0; i < playersPosition.Length; i++)
            playersPosition[i] = 0;
        for (int i = 0; i < nextGame.Length; i++)
            nextGame[i] = false;
        nowPlayer = 3;
        nowBonus = -1;
        isGame = false;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioPlay();
            if (panelExit.activeSelf)
                PanelExit(true);
            else
                PanelExit(false);
        }
    }

    public void PanelExit(bool isOpen)
    {
        Time.timeScale = isOpen ? 1 : 0;
        panelExit.SetActive(!isOpen);
    }

    public void MenuOrBoard()
    {
        PanelExit(true);
        if (!isGame || SceneManager.GetActiveScene().name == "Board")
            SceneManager.LoadScene("MainMenu");
        else
            SceneManager.LoadScene("Board");
    }

    public void AudioPlay()
    {
        audioSource.Play();
    }
}
