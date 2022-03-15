using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject clickPrefab;
    public GameObject musicPrefab;
    public GameObject options;

    public GameObject menu;
    public GameObject miniGames;
    public GameObject panel;

    private AudioSource audioSource;
    private BasicValues basicValues;
    static private bool wasStart = false;

    private void Start()
    {
        Cursor.visible = true;

        GameObject click;
        GameObject notDestroy;
        if (!wasStart)
        {
            click = Instantiate(clickPrefab);
            DontDestroyOnLoad(click);
            notDestroy = Instantiate(musicPrefab);
            wasStart = true;
        }
        else
        {
            click = GameObject.Find("Click(Clone)");
            notDestroy = GameObject.Find("NotDestroy(Clone)");
        }

        options.GetComponent<Options>().StartOptions();

        basicValues = notDestroy.GetComponent<BasicValues>();
        if (basicValues.isGame)
            menu.SetActive(true);
        else
            miniGames.SetActive(true);
        basicValues.Reload();

        audioSource = click.GetComponent<AudioSource>();
    }

    public void ChangeCountOfPlayers(int count)
    {
        basicValues.playersCount = count;
        basicValues.isGame = true;
        SceneManager.LoadScene("Board");
    }

    public void PlayMiniGame(string game)
    {
        SceneManager.LoadScene(game);
    }

    public void AudioPlay()
    {
        audioSource.Play();
    }

    public void Quit() //нажали на кнопку "Выйти из игры"
    {
        Application.Quit();
    }
}