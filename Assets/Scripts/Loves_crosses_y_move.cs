using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loves_crosses_y_move : MonoBehaviour
{
    public float speed       = 0.02f;
    public float t0_await    = 0.5f;
    public float t_await     = 10.0f;
    
    public Vector2 start_position_t  = new Vector2(-1.07f, 5.16f);
    public float limit_position_yt   = 2.37f;
    public Vector2 start_position_b  = new Vector2(-1.07f, -5.12f);
    public float limit_position_yb   = -1.36f;
    public GameObject love1_t; public GameObject love2_t;
    public GameObject love3_t; public GameObject cross_t;
    public GameObject love1_b; public GameObject love2_b;
    public GameObject love3_b; public GameObject cross_b;
    bool[] levers = new bool[8] { false, false, false, false, false, false, false, false, };
    Vector2 y1t; Vector2 y1b;
    Vector2 y2t; Vector2 y2b;
    Vector2 y3t; Vector2 y3b;
    Vector2 y4t; Vector2 y4b;

    void FixedUpdate()
    {  
        // top items
        if (!levers[0] &&
                ((y1t != start_position_t) || ((y2t.y < 4.34f) && (y3t.y < 4.34f) && (y4t.y < 4.34f)) ||
                ((y1t == start_position_t) && (y2t == start_position_t) && (y3t == start_position_t) && (y4t.y < 4.34f)) || // 1 2 3 in start pos
                ((y1t == start_position_t) && (y2t == start_position_t) && (y3t.y < 4.34f) && (y4t.y < 4.34f)) || // 1 2 in start pos
                ((y1t == start_position_t) && (y3t == start_position_t) && (y2t.y < 4.34f) && (y4t.y < 4.34f))))  // 1 3 in start pos
                {
                    y1t = Move_t(love1_t);
                }
        if (y1t == start_position_t) {
            StartCoroutine(waiter(levers, 0));
        }
        if (!levers[1] &&
                ((y2t != start_position_t) || ((y1t.y < 4.34f) && (y3t.y < 4.34f) && (y4t.y < 4.34f)) ||
                ((y2t == start_position_t) && (y3t == start_position_t) && (y4t == start_position_t) && (y1t.y < 4.34f)) || // 2 3 4 in start pos
                ((y2t == start_position_t) && (y3t == start_position_t) && (y1t.y < 4.34f) && (y4t.y < 4.34f)))) // 2 3 in start pos
                {
                    y2t = Move_t(love2_t);
                }
        if (y2t == start_position_t) {
            StartCoroutine(waiter(levers, 1));
        }
        if (!levers[2] &&
                ((y3t != start_position_t) || ((y1t.y < 4.34f) && (y2t.y < 4.34f) && (y4t.y < 4.34f)) ||
                ((y3t == start_position_t) && (y4t == start_position_t) && (y1t == start_position_t) && (y2t.y < 4.34f)) || // 3 4 1 in start pos
                ((y3t == start_position_t) && (y4t == start_position_t) && (y1t.y < 4.34f) && (y2t.y < 4.34f)))) // 3 4 in start pos
                {
                    y3t = Move_t(love3_t);
                }
        if (y3t == start_position_t) {
            StartCoroutine(waiter(levers, 2));
        }
        if (!levers[3] &&
                ((y4t != start_position_t) || ((y1t.y < 4.34f) && (y2t.y < 4.34f) && (y3t.y < 4.34f)) ||
                ((y4t == start_position_t) && (y1t == start_position_t) && (y2t == start_position_t) && (y3t.y < 4.34f)) || // 4 1 2 in start pos
                ((y4t == start_position_t) && (y1t == start_position_t) && (y2t.y < 4.34f) && (y3t.y < 4.34f)) || // 4 1 in start pos
                ((y4t == start_position_t) && (y2t == start_position_t) && (y1t.y < 4.34f) && (y3t.y < 4.34f))))  // 4 2 in start pos
                {
                    y4t = Move_t(cross_t);
                }
        if (y4t == start_position_t) {
            StartCoroutine(waiter(levers, 3));
        }
    
        // bottom items
        if (!levers[4] &&
                ((y1b != start_position_b) || ((y2b.y > -4.31f) && (y3b.y > -4.31f) && (y4b.y > -4.31f)) ||
                ((y1b == start_position_b) && (y2b == start_position_b) && (y3b == start_position_b) && (y4b.y > -4.31f)) || // 1 2 3 in start pos
                ((y1b == start_position_b) && (y2b == start_position_b) && (y3b.y > -4.31f) && (y4b.y > -4.31f)) || // 1 2 in start pos
                ((y1b == start_position_b) && (y3b == start_position_b) && (y2b.y > -4.31f) && (y4b.y > -4.31f))))  // 1 3 in start pos
                {
                    y1b = Move_b(love1_b);
                }
        if (y1b == start_position_b) {
            StartCoroutine(waiter(levers, 4));
        }
        if (!levers[5] &&
                ((y2b != start_position_b) || ((y1b.y > -4.31f) && (y3b.y > -4.31f) && (y4b.y > -4.31f)) ||
                ((y2b == start_position_b) && (y3b == start_position_b) && (y4b == start_position_b) && (y1b.y > -4.31f)) || // 2 3 4 in start pos
                ((y2b == start_position_b) && (y3b == start_position_b) && (y1b.y > -4.31f) && (y4b.y > -4.31f)))) // 2 3 in start pos
                {
                    y2b = Move_b(love2_b);
                }
        if (y2b == start_position_b) {
            StartCoroutine(waiter(levers, 5));
        }
        if (!levers[6] &&
                ((y3b != start_position_b) || ((y1b.y > -4.31f) && (y2b.y > -4.31f) && (y4b.y > -4.31f)) ||
                ((y3b == start_position_b) && (y4b == start_position_b) && (y1b == start_position_b) && (y2b.y > -4.31f)) || // 3 4 1 in start pos
                ((y3b == start_position_b) && (y4b == start_position_b) && (y1b.y > -4.31f) && (y2b.y > -4.31f)))) // 3 4 in start pos
                {
                    y3b = Move_b(love3_b);
                }
        if (y3b == start_position_b) {
            StartCoroutine(waiter(levers, 6));
        }
        if (!levers[7] &&
                ((y4b != start_position_b) || ((y1b.y > -4.31f) && (y2b.y > -4.31f) && (y3b.y > -4.31f)) ||
                ((y4b == start_position_b) && (y1b == start_position_b) && (y2b == start_position_b) && (y3b.y > -4.31f)) || // 4 1 2 in start pos
                ((y4b == start_position_b) && (y1b == start_position_b) && (y2b.y > -4.31f) && (y3b.y > -4.31f)) || // 4 1 in start pos
                ((y4b == start_position_b) && (y2b == start_position_b) && (y1b.y > -4.31f) && (y3b.y > -4.31f))))  // 4 2 in start pos
                {
                    y4b = Move_b(cross_b);
                }
        if (y4b == start_position_b) {
            StartCoroutine(waiter(levers, 7));
        }
    }

    // COROUTINES

    IEnumerator waiter(bool[] levers, int i)
    {
        levers[i] = true;
        yield return new WaitForSeconds(Random.Range(t0_await, t_await));
        levers[i] = false;
    }

    // MOVEMENT

    Vector2 Move_t(GameObject item)
    {// top movement
        item.transform.Translate(new Vector2(0, -1).normalized * speed);
        if (item.transform.position.y <= limit_position_yt)
        {
            item.transform.position = start_position_t;
        }
        return item.transform.position;
    }

    Vector2 Move_b(GameObject item)
    {// bottom movement
        item.transform.Translate(new Vector2(0, 1).normalized * speed);
        if (item.transform.position.y >= limit_position_yb)
        {
            item.transform.position = start_position_b;
        }
        return item.transform.position;
    }
}
