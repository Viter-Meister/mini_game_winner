using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoardMain : MonoBehaviour
{
    public GameObject dice;
    public GameObject player;
    public Transform[] spawns;
    public Color[] colors;
    public string[] games;

    public Image[] PanelPlayers;
    public GameObject YourMove;
    public GameObject NextGame;

    private BasicValues basicValues;
    private GameObject[] players = new GameObject[4];
    private float offset = 0.07f;
    private int end = 30;

    private void Start()
    {
        basicValues = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();
        SpawnPlayers(basicValues.playersCount);
        AfterGame();
    }

    public void SpawnPlayers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            players[i] = Instantiate(player, spawns[basicValues.playersPosition[i]].position
                + new Vector3(offset * i, 0), transform.rotation);
            players[i].GetComponent<SpriteRenderer>().color = colors[i];
        }
    }

    public void AfterGame()
    {
        NextPlayer();
        PanelPlayers[0].color = colors[basicValues.nowPlayer];
        YourMove.SetActive(true);
    }

    public void AudioPlay()
    {
        GameObject.Find("Click(Clone)").GetComponent<AudioSource>().Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Dice()
    {
        dice.SetActive(true);
    }

    private void NextPlayer()
    {
        basicValues.nowPlayer++;
        if (basicValues.nowPlayer >= basicValues.playersCount)
            basicValues.nowPlayer = 0;
    }

    public void FromDice(int side)
    {
        StartCoroutine(Move(basicValues.nowPlayer, side));
    }

    public void LoadGame()
    {
        bool game = basicValues.nextGame[basicValues.nowPlayer];
        basicValues.nextGame[basicValues.nowPlayer] = false;
        if (!game)
            SceneManager.LoadScene(games[Random.Range(0, games.Length)]);
        else
            SceneManager.LoadScene(games[0]);
    }

    private IEnumerator Move(int player, int length)
    {
        for (int i = basicValues.playersPosition[player]; i <= basicValues.playersPosition[player] + length; i++)
        {
            if (i > end)
                break;
            players[player].transform.position = spawns[i].position + new Vector3(offset * player, 0);
            yield return new WaitForSeconds(0.2f);
        }
        basicValues.playersPosition[player] += (length > end) ? end : length;
        yield return new WaitForSeconds(1);
        PanelPlayers[1].color = colors[basicValues.nowPlayer];
        NextGame.SetActive(true);
    }
}
