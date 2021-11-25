using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject clickPrefab;
    public GameObject musicPrefab;
    public GameObject options;

    public GameObject menu;
    public GameObject panel;

    private AudioSource audioSource;
    static private bool isStart = false;

    private void Start()
    {
        Cursor.visible = true;

        GameObject click;
        if (!isStart)
        {
            Instantiate(musicPrefab);
            click = Instantiate(clickPrefab);
            DontDestroyOnLoad(click);
            isStart = true;
        }
        else
            click = GameObject.Find("Click(Clone)");

        options.GetComponent<Options>().StartOptions();

        audioSource = click.GetComponent<AudioSource>();
    }

    public void Singleplayer() //нажали на кнопку "Одиночный режим"
    {
        menu.SetActive(false);
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