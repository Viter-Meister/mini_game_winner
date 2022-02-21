using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardMain : MonoBehaviour
{
    public GameObject dice;
    public GameObject player;
    public Transform[] spawns;
    public Color[] colors;
    public string[] games;

    private BasicValues basicValues;
    private GameObject[] players = new GameObject[4];
    private float offset = 0.07f;
    private int end = 30;

    private void Start()
    {
        basicValues = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();
        SpawnPlayers(basicValues.playersCount);
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

    public void AudioPlay()
    {
        GameObject.Find("Click(Clone)").GetComponent<AudioSource>().Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            dice.SetActive(true);
    }

    private void NextPlayer()
    {
        basicValues.nowPlayer++;
        if (basicValues.nowPlayer == basicValues.playersCount)
            basicValues.nowPlayer = 0;
    }

    public void FromDice(int side)
    {
        StartCoroutine(Move(basicValues.nowPlayer, side));
    }

    public void ChooseTheGame()
    {
        int game = basicValues.nextGame[basicValues.nowPlayer];
        basicValues.nextGame[basicValues.nowPlayer] = -1;
        if (game != -1)
            SceneManager.LoadScene(games[game]);
        else
            SceneManager.LoadScene(games[Random.Range(0, games.Length)]);
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
        ChooseTheGame();
    }
}
