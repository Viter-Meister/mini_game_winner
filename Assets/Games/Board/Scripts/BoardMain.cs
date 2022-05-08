using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoardMain : MonoBehaviour
{
    public GameObject SmallBoard;
    public GameObject BigBoard;

    public GameObject dice;
    public Sprite[] bonuses;
    public GameObject player1;
    public GameObject player2;
    private GameObject player;
    public Transform[] spawns;
    public Transform[] spawnsBigMap;
    public Color[] colors;
    public string[] games;

    public GameObject PlayerToggle;
    public Image[] PanelPlayers;
    public GameObject YourMove;
    public GameObject Bonus;
    public GameObject Gift;
    public GameObject GiftLuck;
    public GameObject GiftNotLuck;
    public GameObject ChoiceGameOnePlayer;
    public GameObject ChoiceGameTwoPlayers;
    public GameObject End;
    public GameObject NextGameOnePlayer;
    public GameObject NextGameTwoPlayers;
    public GameObject NextGameManyPlayers;

    public GameObject ConfettinFX;
    public GameObject Cup;

    private BasicValues basicValues;
    private GameObject[] players = new GameObject[4];
    private float offset = 0.15f;
    private int end = 30;

    private void Start()
    {
        basicValues = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();
        player = player1;
        if (!basicValues.isSmallMap)
        {
            GetComponent<Camera>().backgroundColor = new Color32(2, 4, 41, 255);
            spawns = spawnsBigMap;
            player = player2;
            end = 51;
            offset = 0.05f;
            BigBoard.SetActive(true);
        }
        else
        {
            GetComponent<Camera>().backgroundColor = new Color32(228, 198, 129, 255);
            SmallBoard.SetActive(true);
        }
        
        SpawnPlayers(basicValues.playersCount);
        Invoke("FromStart", 0.1f);
    }

    private void FromStart()
    {
        if (basicValues.nowBonus == -1)
            AfterGame();
        else
        {
            Panel(Bonus, 8);
            PanelPlayers[9].sprite = bonuses[basicValues.nowBonus];
        }
    }

    public void FromGift(bool isYes)
    {
        if (!isYes)
            ResetBonusAndNextPlayer();
        else
        {
            int r = Random.Range(0, 2);
            Panel(r == 0 ? GiftLuck : GiftNotLuck, r == 0 ? 12 : 13);
        }
    }

    public void FromGiftYes(bool isLuck)
    {
        if (isLuck)
            StartCoroutine(Move(basicValues.nowPlayer, end, true));
        else
            StartCoroutine(Move(basicValues.nowPlayer, -end, true));
    }

    public void FromBonus()
    {
        if (basicValues.nowBonus == 0)
            StartCoroutine(Move(basicValues.nowPlayer, 1, true));
        if (basicValues.nowBonus == 1)
            StartCoroutine(Move(basicValues.nowPlayer, 2, true));
        else if (basicValues.nowBonus == 2)
        {
            basicValues.nextGame[basicValues.nowPlayer] = true;
            ResetBonusAndNextPlayer();
        }
        else if (basicValues.nowBonus == 3)
            StartCoroutine(Move(basicValues.nowPlayer, 3, true));
        else if (basicValues.nowBonus == 4)
            Panel(Gift, 11);
        else if (basicValues.nowBonus == 5)
            StartCoroutine(Move(basicValues.nowPlayer, 4, true));
        else if (basicValues.nowBonus == 6)
            StartCoroutine(Move(basicValues.nowPlayer, basicValues.nowLength, true));
        else if (basicValues.nowBonus == 7)
            StartCoroutine(Move(basicValues.nowPlayer, 5, true));
        else if (basicValues.nowBonus == 8)
            StartCoroutine(Move(basicValues.nowPlayer, basicValues.nowLength * 2, true));
        else
        {
            NextPlayer();
            AfterGame();
        }
    }

    private void ResetBonusAndNextPlayer()
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

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
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
        StartCoroutine(Move(basicValues.nowPlayer, side, false));
    }

    public void LoadGame(bool isOnePlayerGame)
    {
        int game;
        if (isOnePlayerGame)
        {
            do game = Random.Range(0, 6);
            while (game == basicValues.previousGame);
        }
        else
        {
            do game = Random.Range(6, games.Length);
            while (game == basicValues.previousGame);
        }
        basicValues.previousGame = game;
        if (game >= 6)
            basicValues.OpenControls();
        SceneManager.LoadScene(games[game]);
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

    private IEnumerator Move(int player, int length, bool isBonus)
    {
        yield return new WaitForSeconds(0.5f);
        basicValues.nowLength = length;
        for (int i = 0; i < Mathf.Abs(length); i++)
        {
            basicValues.playersPosition[player] += (int)Mathf.Sign(length);
            players[player].transform.position = spawns[basicValues.playersPosition[player]].position
                + new Vector3(offset * player, 0);
            if (basicValues.playersPosition[player] == 0 || basicValues.playersPosition[player] == end)
                break;
            yield return new WaitForSeconds(0.2f);
        }
        
        yield return new WaitForSeconds(1);

        if (basicValues.playersPosition[player] >= end)
        {
            Instantiate(ConfettinFX, Camera.main.transform.position + new Vector3(5,7), Quaternion.identity);
            Instantiate(ConfettinFX, Camera.main.transform.position + new Vector3(-5, 7), Quaternion.identity);
            Instantiate(Cup, new Vector3(0, 2.5f,-5), Quaternion.identity);
            Panel(End, 10);
        }
        else
        {
            if (isBonus)
                ResetBonusAndNextPlayer();
            else
            {
                if (basicValues.nextGame[player])
                {
                    basicValues.nextGame[player] = false;
                    if (basicValues.playersCount == 1)
                        Panel(ChoiceGameOnePlayer, 14);
                    else
                        Panel(ChoiceGameTwoPlayers, 15);
                }
                else
                {
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
        }
    }
}
