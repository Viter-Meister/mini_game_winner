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
    public int previousGame;
    public int nowBonus;
    public int nowLength;
    public bool isSmallMap;
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
        previousGame = -1;
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

    public void ChooseBonus(int bonus)
    {
        switch (bonus)
        {
            case 1:
                nowBonus = Random.Range(0, 2);
                break;
            case 2:
                nowBonus = Random.Range(0, 4);
                break;
            case 3:
                nowBonus = Random.Range(0, 6);
                break;
            case 4:
                nowBonus = Random.Range(0, 8);
                break;
            case 5:
                nowBonus = Random.Range(0, 9);
                break;
            case 6:
                nowBonus = Random.Range(0, 10);
                break;
            default:
                break;
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