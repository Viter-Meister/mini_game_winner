using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;
}

public class MazeGenerator
{
    public int Widht = 10;
    public int Hieght = 10;

    public MazeGeneratorCell[,] GenerateMaze()
    {
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Widht, Hieght];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }

        for (int x = 0; x < maze.GetLength(0); x++)
            maze[x, Hieght - 1].WallLeft = false;

        for (int y = 0; y < maze.GetLength(1); y++)
            maze[Widht - 1, y].WallBottom = false;

        RemoveWallWithTracker(maze);

        return maze;
    }

    private void RemoveWallWithTracker(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0, 0];
        current.Visited = true;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            List<MazeGeneratorCell> UnvisitedNeig = new List<MazeGeneratorCell>();

            if (current.X > 0 && !maze[current.X - 1, current.Y].Visited)
                UnvisitedNeig.Add(maze[current.X - 1, current.Y]);
            if (current.Y > 0 && !maze[current.X, current.Y - 1].Visited)
                UnvisitedNeig.Add(maze[current.X, current.Y - 1]);
            if (current.X  < Widht - 2 && !maze[current.X + 1, current.Y].Visited)
                UnvisitedNeig.Add(maze[current.X + 1, current.Y]);
            if (current.Y < Hieght - 2 && !maze[current.X, current.Y + 1].Visited)
                UnvisitedNeig.Add(maze[current.X, current.Y + 1]);

            if (UnvisitedNeig.Count > 0)
            {
                MazeGeneratorCell chosen = UnvisitedNeig[Random.Range(0, UnvisitedNeig.Count)];

                RemoveWall(chosen, current);
                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y)
                a.WallBottom = false;
            else
                b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X)
                a.WallLeft = false;
            else
                b.WallLeft = false;
        }
    }
}
