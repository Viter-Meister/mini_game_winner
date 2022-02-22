using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrail : MonoBehaviour
{
    public GameObject Player;
    public GameObject AnotherPlayer;

    private LineRenderer line;
    public List<Vector2> pointsList;

    private new EdgeCollider2D collider;

    public int TrailLength = 0;
    private int MaxTrailLenght = 150;

    private float IncMaxLenght = 5;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        collider = gameObject.GetComponent<EdgeCollider2D>();

        pointsList = new List<Vector2>();
    }

    private void Update()
    {
        if (!pointsList.Contains(Player.transform.position))
        {
            pointsList.Add(Player.transform.position);
            line.positionCount = pointsList.Count;
            line.SetPosition(pointsList.Count - 1, pointsList[pointsList.Count - 1]);

            if (pointsList.Count > 1)
            {
                collider.points = pointsList.ToArray();
                collider.enabled = true;
            }

            TrailLength += 1;

            RemovePointInLine();
        }

        if (IncMaxLenght > 0)
        {
            IncMaxLenght -= Time.deltaTime;
        }
        else
        {
            IncMaxLenght = 5;
            MaxTrailLenght += 10;
        }
    }

    private void RemovePointInLine()
    {
        if (TrailLength == MaxTrailLenght)
        {
            line.positionCount = 0;
            pointsList.RemoveAt(0);
            line.positionCount = pointsList.Count;
            for (int i = 0; i < pointsList.Count; i++)
            {
                line.SetPosition(i, pointsList[i]);
            }
            TrailLength -= 1;
        }
    }
}
