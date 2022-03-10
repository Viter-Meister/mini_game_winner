using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoardMain : MonoBehaviour
{
    public GameObject dice;
    public Sprite[] bonuses;
    public GameObject player;
    public Transform[] spawns;
    public Color[] colors;
    public string[] games;

    public GameObject PlayerToggle;
    public Image[] PanelPlayers;
    public GameObject YourMove;
    public GameObject Bonus;
    public GameObject NextGameOnePlayer;
    public GameObject NextGameTwoPlayers;
    public GameObject NextGameManyPlayers;

    private BasicValues basicValues;
    private GameObject[] players = new GameObject[4];
    private float offset = 0.07f;
    private int end = 30;

    private void Start()
    {
        basicValues = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();
        SpawnPlayers(basicValues.playersCount);
        if (basicValues.nowBonus == -1)
            AfterGame();
        else
        {
            Panel(Bonus, 8);
            PanelPlayers[9].sprite = bonuses[basicValues.nowBonus];
        }
    }

    public void FromBonus()
    {
        basicValues.nowBonus = -1;
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
        Panel(YourMove, 0);
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

    public void LoadGame(bool isOnePlayerGame)
    {
        //bool game = basicValues.nextGame[basicValues.nowPlayer];
        //basicValues.nextGame[basicValues.nowPlayer] = false;
        if (isOnePlayerGame)
            SceneManager.LoadScene(games[Random.Range(0, 4)]);
        else
            SceneManager.LoadScene(games[Random.Range(4, games.Length)]);
    }

    private void Panel(GameObject NextGame, int nowPlayerColor)
    {
        PanelPlayers[nowPlayerColor].color = colors[basicValues.nowPlayer];
        if (nowPlayerColor == 2)
            PanelPlayers[4].color = colors[basicValues.nowPlayer == 0 ? 1 : 0];
        if (nowPlayerColor == 3)
        {
            PlayerToggle.SetActive(basicValues.playersCount == 4);
            int j = 0;
            for (int i = 0; i < 4; i++)
                if (i != basicValues.nowPlayer)
                {
                    PanelPlayers[5 + j].color = colors[i];
                    j++;
                }
        }
        NextGame.SetActive(true);
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
        
        int whatGame = Random.Range(0, 2);
        if (basicValues.playersCount == 1 || whatGame == 0)
            Panel(NextGameOnePlayer, 1);
        else
        {
            if (basicValues.playersCount == 2)
                Panel(NextGameTwoPlayers, 2);
            else
                Panel(NextGameManyPlayers, 3);
        }
    }
}
