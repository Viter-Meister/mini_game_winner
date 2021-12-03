using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMain : MonoBehaviour
{
    public GameObject dice;
    public GameObject player;
    public Transform[] spawns;
    public Color[] colors;

    private GameObject[] players = new GameObject[4];

    void Start()
    {
        SpawnPlayers(1);
    }

    public void SpawnPlayers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            players[i] = Instantiate(player, spawns[0].position + new Vector3(0.07f * i, 0), transform.rotation);
            players[i].GetComponent<SpriteRenderer>().color = colors[i];
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            dice.SetActive(true);
    }

    public void FromDice(int side)
    {
        StartCoroutine(Move(0, side + 1));
    }

    public void MovePlayer(int player, int length)
    {
        BoardPlayer boardPlayer = players[player].GetComponent<BoardPlayer>();
        boardPlayer.position += length;
        players[player].transform.position = spawns[boardPlayer.position].position;
    }

    private IEnumerator Move(int player, int length)
    {
        BoardPlayer boardPlayer = players[player].GetComponent<BoardPlayer>();

        for (int i = boardPlayer.position; i <= boardPlayer.position + length; i++)
        {
            if (i > 30)
                break;
            players[player].transform.position = spawns[i].position + new Vector3(0.07f * player, 0);
            yield return new WaitForSeconds(0.2f);
        }
        
        boardPlayer.position = boardPlayer.position + length > 30 ? 30 : boardPlayer.position + length;
    }
}
