using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePartOfTrail : MonoBehaviour
{
    private LineRenderer line;
    public List<Vector2> pointsListPart;

    private List<Vector2> pointLIstParent;

    private new EdgeCollider2D collider;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        collider = gameObject.GetComponent<EdgeCollider2D>();

        pointLIstParent = GetComponentInParent<DrawTrail>().pointsList;

        pointsListPart = new List<Vector2>();
        if (pointLIstParent.Count >= 5)
        {
            for (int i = 0; i < 35; i++)
            {
                pointsListPart.Add(pointLIstParent[i]);
            }
        }

        pointLIstParent.Clear();

        line.positionCount = pointsListPart.Count;
        for (int i = 0; i < 35; i++)
        {
            line.SetPosition(i, pointsListPart[i]);
        }

        if (pointsListPart.Count > 1)
        {
            collider.points = pointsListPart.ToArray();
            collider.enabled = true;
        }
    }
}
