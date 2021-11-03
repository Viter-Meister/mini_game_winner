using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private BoxePos nowBox = new BoxePos(-7.5f, -3.65f);
    public float BoxeChangePlaceSpeed = 0.5f;

    private List<Vector2> AllBoxePosition = new List<Vector2>();

    private void Start()
    {
        StartCoroutine(ShowBoxePlace());
    }

    IEnumerator ShowBoxePlace()
    {
        while (true)
        {
            SpawnPosition();

            yield return new WaitForSeconds(BoxeChangePlaceSpeed);
        }
    }

    private void SpawnPosition()
    {
        List<Vector2> positions = new List<Vector2>();
        float x = -7.5f;
        
    }

    private bool IsPositionEmpty(Vector2 targetPos)
    {
        if (targetPos.y < -3.65)
            return false;
        foreach (var pos in AllBoxePosition)
            if (pos.x == targetPos.x && pos.y == targetPos.y)
                return false;
        return true;
    }
}

struct BoxePos
{
    public float x, y;

    public BoxePos(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 getVector()
    {
        return new Vector2(x, y);
    }

    public void setVector(Vector2 pos)
    {
        x = pos.x;
        y = pos.y;
    }
}