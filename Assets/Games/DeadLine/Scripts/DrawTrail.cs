using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrail : MonoBehaviour
{
    public GameObject Player;
    public GameObject AnotherPlayer;

    public GameObject PartOfTrail;

    public List<Vector2> pointsList;


    public float CountToGap = 0;

    private void Start()
    {
        pointsList = new List<Vector2>();
    }

    private void Update()
    {
        if (!pointsList.Contains(Player.transform.position))
        {
            pointsList.Add(Player.transform.position);
            CountToGap += 1;
        }

        if (CountToGap % 50 == 0)
        {
            GameObject child = Instantiate(PartOfTrail);
            child.transform.SetParent(this.transform);
        }
    }
}
