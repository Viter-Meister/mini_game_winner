using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject Maze;
    public GameObject Coins;

    public GameObject cell;
    public GameObject Coin;
    public GameObject BonusChest;

    private int CountCoins = 101;
    private List<Vector2> TakenPosition = new List<Vector2>();

    void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GenerateMaze();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(cell, new Vector2(x, y), Quaternion.identity, Maze.transform).GetComponent<Cell>();

                SpawnCoins();

                c.LeftWall.SetActive(maze[x, y].WallLeft);
                c.BottomWall.SetActive(maze[x, y].WallBottom);
            }
        }
    }

    void SpawnCoins()
    {
        int x = Random.Range(0, 19);
        int y = Random.Range(0, 19);

        Vector2 vec = new Vector2(x, y);

        while (CountCoins > 0)
        {
            if (CountCoins == 1 && !TakenPosition.Contains(vec))
            {
                Instantiate(BonusChest, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity, Coins.transform);
                TakenPosition.Add(vec);
                CountCoins -= 1;
            }
            else if (!TakenPosition.Contains(vec))
            {
                Instantiate(Coin, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity, Coins.transform);
                TakenPosition.Add(vec);
                CountCoins -= 1;
            }

            x = Random.Range(0, 19);
            y = Random.Range(0, 19);

            vec = new Vector2(x, y);
        }
    }
}
