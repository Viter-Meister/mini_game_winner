using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loves_crosses_x_move : MonoBehaviour
{
    public float speed       = 0.02f;
    public float t0_await    = 0.5f;
    public float t_await     = 10.0f;
    
    public Vector2 start_position_r        = new Vector2(5.47f, 0.59f);
    public Vector2 cross_start_position_r  = new Vector2(5.47f, 0.55f);
    public float limit_position_xr         = 0.9f;
    public Vector2 start_position_l        = new Vector2(-7.75f, 0.59f);
    public Vector2 cross_start_position_l  = new Vector2(-7.75f, 0.55f);
    public float limit_position_xl         = -2.84f;
    public GameObject love1_r; public GameObject love2_r;
    public GameObject love3_r; public GameObject cross_r;
    public GameObject love1_l; public GameObject love2_l;
    public GameObject love3_l; public GameObject cross_l;
    bool[] levers = new bool[8] { false, false, false, false, false, false, false, false, };
    Vector2 x1r; Vector2 x1l;
    Vector2 x2r; Vector2 x2l;
    Vector2 x3r; Vector2 x3l;
    Vector2 x4r; Vector2 x4l;

    void FixedUpdate()
    {  
        // right items
        if (!levers[0] &&
                ((x1r != start_position_r) || ((x2r.x < 4.4f) && (x3r.x < 4.4f) && (x4r.x < 4.4f)) ||
                ((x1r == start_position_r) && (x2r == start_position_r) && (x3r == start_position_r) && (x4r.x < 4.4f)) || // 1 2 3 in start pos
                ((x1r == start_position_r) && (x2r == start_position_r) && (x3r.x < 4.4f) && (x4r.x < 4.4f)) || // 1 2 in start pos
                ((x1r == start_position_r) && (x3r == start_position_r) && (x2r.x < 4.4f) && (x4r.x < 4.4f))))  // 1 3 in start pos
                {
                    x1r = Move_r(love1_r);
                }
        if (x1r == start_position_r) {
            StartCoroutine(waiter(levers, 0));
        }
        if (!levers[1] &&
                ((x2r != start_position_r) || ((x1r.x < 4.4f) && (x3r.x < 4.4f) && (x4r.x < 4.4f)) ||
                ((x2r == start_position_r) && (x3r == start_position_r) && (x4r == cross_start_position_r) && (x1r.x < 4.4f)) || // 2 3 4 in start pos
                ((x2r == start_position_r) && (x3r == start_position_r) && (x1r.x < 4.4f) && (x4r.x < 4.4f)))) // 2 3 in start pos
                {
                    x2r = Move_r(love2_r);
                }
        if (x2r == start_position_r) {
            StartCoroutine(waiter(levers, 1));
        }
        if (!levers[2] &&
                ((x3r != start_position_r) || ((x1r.x < 4.4f) && (x2r.x < 4.4f) && (x4r.x < 4.4f)) ||
                ((x3r == start_position_r) && (x4r == cross_start_position_r) && (x1r == start_position_r) && (x2r.x < 4.4f)) || // 3 4 1 in start pos
                ((x3r == start_position_r) && (x4r == cross_start_position_r) && (x1r.x < 4.4f) && (x2r.x < 4.4f)))) // 3 4 in start pos
                {
                    x3r = Move_r(love3_r);
                }
        if (x3r == start_position_r) {
            StartCoroutine(waiter(levers, 2));
        }
        if (!levers[3] &&
                ((x4r != cross_start_position_r) || ((x1r.x < 4.4f) && (x2r.x < 4.4f) && (x3r.x < 4.4f)) ||
                ((x4r == cross_start_position_r) && (x1r == start_position_r) && (x2r == start_position_r) && (x3r.x < 4.4f)) || // 4 1 2 in start pos
                ((x4r == cross_start_position_r) && (x1r == start_position_r) && (x2r.x < 4.4f) && (x3r.x < 4.4f)) || // 4 1 in start pos
                ((x4r == cross_start_position_r) && (x2r == start_position_r) && (x1r.x < 4.4f) && (x3r.x < 4.4f))))  // 4 2 in start pos
                {
                    x4r = Move_r(cross_r);
                }
        if (x4r == cross_start_position_r) {
            StartCoroutine(waiter(levers, 3));
        }
    
        // left items
        if (!levers[4] &&
                ((x1l != start_position_l) || ((x2l.x > -6.73f) && (x3l.x > -6.73f) && (x4l.x > -6.73f)) ||
                ((x1l == start_position_l) && (x2l == start_position_l) && (x3l == start_position_l) && (x4l.x > -6.73f)) || // 1 2 3 in start pos
                ((x1l == start_position_l) && (x2l == start_position_l) && (x3l.x > -6.73f) && (x4l.x > -6.73f)) || // 1 2 in start pos
                ((x1l == start_position_l) && (x3l == start_position_l) && (x2l.x > -6.73f) && (x4l.x > -6.73f))))  // 1 3 in start pos
                {
                    x1l = Move_l(love1_l);
                }
        if (x1l == start_position_l) {
            StartCoroutine(waiter(levers, 4));
        }
        if (!levers[5] &&
                ((x2l != start_position_l) || ((x1l.x > -6.73f) && (x3l.x > -6.73f) && (x4l.x > -6.73f)) ||
                ((x2l == start_position_l) && (x3l == start_position_l) && (x4l == cross_start_position_l) && (x1l.x > -6.73f)) || // 2 3 4 in start pos
                ((x2l == start_position_l) && (x3l == start_position_l) && (x1l.x > -6.73f) && (x4l.x > -6.73f)))) // 2 3 in start pos
                {
                    x2l = Move_l(love2_l);
                }
        if (x2l == start_position_l) {
            StartCoroutine(waiter(levers, 5));
        }
        if (!levers[6] &&
                ((x3l != start_position_l) || ((x1l.x > -6.73f) && (x2l.x > -6.73f) && (x4l.x > -6.73f)) ||
                ((x3l == start_position_l) && (x4l == cross_start_position_l) && (x1l == start_position_l) && (x2l.x > -6.73f)) || // 3 4 1 in start pos
                ((x3l == start_position_l) && (x4l == cross_start_position_l) && (x1l.x > -6.73f) && (x2l.x > -6.73f)))) // 3 4 in start pos
                {
                    x3l = Move_l(love3_l);
                }
        if (x3l == start_position_l) {
            StartCoroutine(waiter(levers, 6));
        }
        if (!levers[7] &&
                ((x4l != cross_start_position_l) || ((x1l.x > -6.73f) && (x2l.x > -6.73f) && (x3l.x > -6.73f)) ||
                ((x4l == cross_start_position_l) && (x1l == start_position_l) && (x2l == start_position_l) && (x3l.x > -6.73f)) || // 4 1 2 in start pos
                ((x4l == cross_start_position_l) && (x1l == start_position_l) && (x2l.x > -6.73f) && (x3l.x > -6.73f)) || // 4 1 in start pos
                ((x4l == cross_start_position_l) && (x2l == start_position_l) && (x1l.x > -6.73f) && (x3l.x > -6.73f))))  // 4 2 in start pos
                {
                    x4l = Move_l(cross_l);
                }
        if (x4l == cross_start_position_l) {
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

    Vector2 Move_r(GameObject item)
    {// right movement
        item.transform.Translate(new Vector2(-1, 0).normalized * speed);
        if (item.transform.position.x <= limit_position_xr)
        {
            if (item == cross_r) { item.transform.position = cross_start_position_r; }
            else { item.transform.position = start_position_r; }
        }
        return item.transform.position;
    }

    Vector2 Move_l(GameObject item)
    {// left movement
        item.transform.Translate(new Vector2(1, 0).normalized * speed);
        if (item.transform.position.x >= limit_position_xl)
        {
            if (item == cross_l) { item.transform.position = cross_start_position_l; }
            else { item.transform.position = start_position_l; }
        }
        return item.transform.position;
    }
}
