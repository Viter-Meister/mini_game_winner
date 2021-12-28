using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject Maze;
    public GameObject Coins;

    public GameObject cell;
    public GameObject Coin;

    void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GenerateMaze();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(cell, new Vector2(x, y), Quaternion.identity, Maze.transform).GetComponent<Cell>();

                if(x < 14 && y < 14)
                    Instantiate(Coin, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity, Coins.transform);

                c.LeftWall.SetActive(maze[x, y].WallLeft);
                c.BottomWall.SetActive(maze[x, y].WallBottom);
            }
        }
    }
}
