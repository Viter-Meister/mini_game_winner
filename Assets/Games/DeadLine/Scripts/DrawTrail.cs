using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrail : MonoBehaviour
{
    public GameObject Player;
    public GameObject AnotherPlayer;

    private LineRenderer line;
    public List<Vector2> pointsList;

    private EdgeCollider2D collider;

    public int TrailLength = 0;

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
    }

    private void RemovePointInLine()
    {
        if (TrailLength == 200)
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
