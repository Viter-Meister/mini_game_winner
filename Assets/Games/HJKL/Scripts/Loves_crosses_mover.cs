using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loves_crosses_mover : MonoBehaviour
{
    public float speed       = 0.02f;
    public float t0_await    = 0.5f;
    public float t_await     = 10.0f;

    public Vector3 start_position_t        = new Vector3(-1.07f, 5.16f, 0.0f);
    public float limit_position_yt         = 1.82f;
    public Vector3 start_position_b        = new Vector3(-1.07f, -5.12f, 0.0f);
    public float limit_position_yb         = -1.35f;    
    public Vector3 start_position_r        = new Vector3(5.45f, 0.6f, 0.0f);
    public Vector3 cross_start_position_r  = new Vector3(5.45f, 0.55f, 0.0f);
    public float limit_position_xr         = 0.87f;
    public Vector3 start_position_l        = new Vector3(-7.8f, 0.6f, 0.0f);
    public Vector3 cross_start_position_l  = new Vector3(-7.8f, 0.55f, 0.0f);
    public float limit_position_xl         = -2.8f;

//  top                        bottom
    public GameObject love1_t; public GameObject love1_b;
    public GameObject love2_t; public GameObject love2_b;
    public GameObject love3_t; public GameObject love3_b;
    public GameObject cross_t; public GameObject cross_b;
// left                        right
    public GameObject love1_l; public GameObject love1_r;
    public GameObject love2_l; public GameObject love2_r;
    public GameObject love3_l; public GameObject love3_r;
    public GameObject cross_l; public GameObject cross_r;

    Vector3 y1t; Vector3 y1b; Vector3 x1l; Vector3 x1r;
    Vector3 y2t; Vector3 y2b; Vector3 x2l; Vector3 x2r;
    Vector3 y3t; Vector3 y3b; Vector3 x3l; Vector3 x3r;
    Vector3 y4t; Vector3 y4b; Vector3 x4l; Vector3 x4r;

    bool[] levers = new bool[16] { false, false, false, false, false, false, false, false,
                                   false, false, false, false, false, false, false, false, };

    Vector3 originscale = new Vector3(0.6186985f, 0.6186985f, 0.0f);
    Vector3 minscale    = new Vector3(0.0f, 0.0f, 0.0f);

    public Text fails; public int fails_num;

    void FixedUpdate()
    {   
        // top items
        if (!levers[0] &&
                ((love1_t.transform.position != start_position_t) || ((y2t.y < 4.34f) && (y3t.y < 4.34f) && (y4t.y < 4.34f)) ||
                ((y1t == start_position_t) && (y2t == start_position_t) && (y3t == start_position_t) && (y4t.y < 4.34f)) || // 1 2 3 in start pos
                ((y1t == start_position_t) && (y2t == start_position_t) && (y3t.y < 4.34f) && (y4t.y < 4.34f)) || // 1 2 in start pos
                ((y1t == start_position_t) && (y3t == start_position_t) && (y2t.y < 4.34f) && (y4t.y < 4.34f))))  // 1 3 in start pos
                {
                    y1t = Move_rt(love1_t, 0, -1, love1_t.transform.position.y, limit_position_yt, false);
                }
        if (love1_t.transform.position == start_position_t) {
            StartCoroutine(Waiter(levers, 0));
        }
        if (!levers[1] &&
                ((love2_t.transform.position != start_position_t) || ((y1t.y < 4.34f) && (y3t.y < 4.34f) && (y4t.y < 4.34f)) ||
                ((y2t == start_position_t) && (y3t == start_position_t) && (y4t == start_position_t) && (y1t.y < 4.34f)) || // 2 3 4 in start pos
                ((y2t == start_position_t) && (y3t == start_position_t) && (y1t.y < 4.34f) && (y4t.y < 4.34f)))) // 2 3 in start pos
                {
                    y2t = Move_rt(love2_t, 0, -1, love2_t.transform.position.y, limit_position_yt, false);
                }
        if (love2_t.transform.position == start_position_t) {
            StartCoroutine(Waiter(levers, 1));
        }
        if (!levers[2] &&
                ((love3_t.transform.position != start_position_t) || ((y1t.y < 4.34f) && (y2t.y < 4.34f) && (y4t.y < 4.34f)) ||
                ((y3t == start_position_t) && (y4t == start_position_t) && (y1t == start_position_t) && (y2t.y < 4.34f)) || // 3 4 1 in start pos
                ((y3t == start_position_t) && (y4t == start_position_t) && (y1t.y < 4.34f) && (y2t.y < 4.34f)))) // 3 4 in start pos
                {
                    y3t = Move_rt(love3_t, 0, -1, love3_t.transform.position.y, limit_position_yt, false);
                }
        if (love3_t.transform.position == start_position_t) {
            StartCoroutine(Waiter(levers, 2));
        }
        if (!levers[3] &&
                ((cross_t.transform.position != start_position_t) || ((y1t.y < 4.34f) && (y2t.y < 4.34f) && (y3t.y < 4.34f)) ||
                ((y4t == start_position_t) && (y1t == start_position_t) && (y2t == start_position_t) && (y3t.y < 4.34f)) || // 4 1 2 in start pos
                ((y4t == start_position_t) && (y1t == start_position_t) && (y2t.y < 4.34f) && (y3t.y < 4.34f)) || // 4 1 in start pos
                ((y4t == start_position_t) && (y2t == start_position_t) && (y1t.y < 4.34f) && (y3t.y < 4.34f))))  // 4 2 in start pos
                {
                    y4t = Move_rt(cross_t, 0, -1, cross_t.transform.position.y, limit_position_yt, false);
                }
        if (cross_t.transform.position == start_position_t) {
            StartCoroutine(Waiter(levers, 3));
        }
    
        // bottom items
        if (!levers[4] &&
                ((love1_b.transform.position != start_position_b) || ((y2b.y > -4.31f) && (y3b.y > -4.31f) && (y4b.y > -4.31f)) ||
                ((y1b == start_position_b) && (y2b == start_position_b) && (y3b == start_position_b) && (y4b.y > -4.31f)) || // 1 2 3 in start pos
                ((y1b == start_position_b) && (y2b == start_position_b) && (y3b.y > -4.31f) && (y4b.y > -4.31f)) || // 1 2 in start pos
                ((y1b == start_position_b) && (y3b == start_position_b) && (y2b.y > -4.31f) && (y4b.y > -4.31f))))  // 1 3 in start pos
                {
                    y1b = Move_lb(love1_b, 0, 1, love1_b.transform.position.y, limit_position_yb, false);
                }
        if (love1_b.transform.position == start_position_b) {
            StartCoroutine(Waiter(levers, 4));
        }
        if (!levers[5] &&
                ((love2_b.transform.position != start_position_b) || ((y1b.y > -4.31f) && (y3b.y > -4.31f) && (y4b.y > -4.31f)) ||
                ((y2b == start_position_b) && (y3b == start_position_b) && (y4b == start_position_b) && (y1b.y > -4.31f)) || // 2 3 4 in start pos
                ((y2b == start_position_b) && (y3b == start_position_b) && (y1b.y > -4.31f) && (y4b.y > -4.31f)))) // 2 3 in start pos
                {
                    y2b = Move_lb(love2_b, 0, 1, love2_b.transform.position.y, limit_position_yb, false);
                }
        if (love2_b.transform.position == start_position_b) {
            StartCoroutine(Waiter(levers, 5));
        }
        if (!levers[6] &&
                ((love3_b.transform.position != start_position_b) || ((y1b.y > -4.31f) && (y2b.y > -4.31f) && (y4b.y > -4.31f)) ||
                ((y3b == start_position_b) && (y4b == start_position_b) && (y1b == start_position_b) && (y2b.y > -4.31f)) || // 3 4 1 in start pos
                ((y3b == start_position_b) && (y4b == start_position_b) && (y1b.y > -4.31f) && (y2b.y > -4.31f)))) // 3 4 in start pos
                {
                    y3b = Move_lb(love3_b, 0, 1, love3_b.transform.position.y, limit_position_yb, false);
                }
        if (love3_b.transform.position == start_position_b) {
            StartCoroutine(Waiter(levers, 6));
        }
        if (!levers[7] &&
                ((cross_b.transform.position != start_position_b) || ((y1b.y > -4.31f) && (y2b.y > -4.31f) && (y3b.y > -4.31f)) ||
                ((y4b == start_position_b) && (y1b == start_position_b) && (y2b == start_position_b) && (y3b.y > -4.31f)) || // 4 1 2 in start pos
                ((y4b == start_position_b) && (y1b == start_position_b) && (y2b.y > -4.31f) && (y3b.y > -4.31f)) || // 4 1 in start pos
                ((y4b == start_position_b) && (y2b == start_position_b) && (y1b.y > -4.31f) && (y3b.y > -4.31f))))  // 4 2 in start pos
                {
                    y4b = Move_lb(cross_b, 0, 1, cross_b.transform.position.y, limit_position_yb, false);
                }
        if (cross_b.transform.position == start_position_b) {
            StartCoroutine(Waiter(levers, 7));
        }

        // right items
        if (!levers[8] &&
                ((love1_r.transform.position != start_position_r) || ((x2r.x < 4.4f) && (x3r.x < 4.4f) && (x4r.x < 4.4f)) ||
                ((x1r == start_position_r) && (x2r == start_position_r) && (x3r == start_position_r) && (x4r.x < 4.4f)) || // 1 2 3 in start pos
                ((x1r == start_position_r) && (x2r == start_position_r) && (x3r.x < 4.4f) && (x4r.x < 4.4f)) || // 1 2 in start pos
                ((x1r == start_position_r) && (x3r == start_position_r) && (x2r.x < 4.4f) && (x4r.x < 4.4f))))  // 1 3 in start pos
                {
                    x1r = Move_rt(love1_r, -1, 0, love1_r.transform.position.x, limit_position_xr, true);
                }
        if (love1_r.transform.position == start_position_r) {
            StartCoroutine(Waiter(levers, 8));
        }
        if (!levers[9] &&
                ((love2_r.transform.position != start_position_r) || ((x1r.x < 4.4f) && (x3r.x < 4.4f) && (x4r.x < 4.4f)) ||
                ((x2r == start_position_r) && (x3r == start_position_r) && (x4r == cross_start_position_r) && (x1r.x < 4.4f)) || // 2 3 4 in start pos
                ((x2r == start_position_r) && (x3r == start_position_r) && (x1r.x < 4.4f) && (x4r.x < 4.4f)))) // 2 3 in start pos
                {
                    x2r = Move_rt(love2_r, -1, 0, love2_r.transform.position.x, limit_position_xr, true);
                }
        if (love2_r.transform.position == start_position_r) {
            StartCoroutine(Waiter(levers, 9));
        }
        if (!levers[10] &&
                ((love3_r.transform.position != start_position_r) || ((x1r.x < 4.4f) && (x2r.x < 4.4f) && (x4r.x < 4.4f)) ||
                ((x3r == start_position_r) && (x4r == cross_start_position_r) && (x1r == start_position_r) && (x2r.x < 4.4f)) || // 3 4 1 in start pos
                ((x3r == start_position_r) && (x4r == cross_start_position_r) && (x1r.x < 4.4f) && (x2r.x < 4.4f)))) // 3 4 in start pos
                {
                    x3r = Move_rt(love3_r, -1, 0, love3_r.transform.position.x, limit_position_xr, true);
                }
        if (love3_r.transform.position == start_position_r) {
            StartCoroutine(Waiter(levers, 10));
        }
        if (!levers[11] &&
                ((cross_r.transform.position != cross_start_position_r) || ((x1r.x < 4.4f) && (x2r.x < 4.4f) && (x3r.x < 4.4f)) ||
                ((x4r == cross_start_position_r) && (x1r == start_position_r) && (x2r == start_position_r) && (x3r.x < 4.4f)) || // 4 1 2 in start pos
                ((x4r == cross_start_position_r) && (x1r == start_position_r) && (x2r.x < 4.4f) && (x3r.x < 4.4f)) || // 4 1 in start pos
                ((x4r == cross_start_position_r) && (x2r == start_position_r) && (x1r.x < 4.4f) && (x3r.x < 4.4f))))  // 4 2 in start pos
                {
                    x4r = Move_rt(cross_r, -1, 0, cross_r.transform.position.x, limit_position_xr, true);
                }
        if (cross_r.transform.position == cross_start_position_r) {
            StartCoroutine(Waiter(levers, 11));
        }
    
        // left items
        if (!levers[12] &&
                ((love1_l.transform.position != start_position_l) || ((x2l.x > -6.73f) && (x3l.x > -6.73f) && (x4l.x > -6.73f)) ||
                ((x1l == start_position_l) && (x2l == start_position_l) && (x3l == start_position_l) && (x4l.x > -6.73f)) || // 1 2 3 in start pos
                ((x1l == start_position_l) && (x2l == start_position_l) && (x3l.x > -6.73f) && (x4l.x > -6.73f)) || // 1 2 in start pos
                ((x1l == start_position_l) && (x3l == start_position_l) && (x2l.x > -6.73f) && (x4l.x > -6.73f))))  // 1 3 in start pos
                {
                    x1l = Move_lb(love1_l, 1, 0, love1_l.transform.position.x, limit_position_xl, true);
                }
        if (love1_l.transform.position == start_position_l) {
            StartCoroutine(Waiter(levers, 12));
        }
        if (!levers[13] &&
                ((love2_l.transform.position != start_position_l) || ((x1l.x > -6.73f) && (x3l.x > -6.73f) && (x4l.x > -6.73f)) ||
                ((x2l == start_position_l) && (x3l == start_position_l) && (x4l == cross_start_position_l) && (x1l.x > -6.73f)) || // 2 3 4 in start pos
                ((x2l == start_position_l) && (x3l == start_position_l) && (x1l.x > -6.73f) && (x4l.x > -6.73f)))) // 2 3 in start pos
                {
                    x2l = Move_lb(love2_l, 1, 0, love2_l.transform.position.x, limit_position_xl, true);
                }
        if (love2_l.transform.position == start_position_l) {
            StartCoroutine(Waiter(levers, 13));
        }
        if (!levers[14] &&
                ((love3_l.transform.position != start_position_l) || ((x1l.x > -6.73f) && (x2l.x > -6.73f) && (x4l.x > -6.73f)) ||
                ((x3l == start_position_l) && (x4l == cross_start_position_l) && (x1l == start_position_l) && (x2l.x > -6.73f)) || // 3 4 1 in start pos
                ((x3l == start_position_l) && (x4l == cross_start_position_l) && (x1l.x > -6.73f) && (x2l.x > -6.73f)))) // 3 4 in start pos
                {
                    x3l = Move_lb(love3_l, 1, 0, love3_l.transform.position.x, limit_position_xl, true);
                }
        if (love3_l.transform.position == start_position_l) {
            StartCoroutine(Waiter(levers, 14));
        }
        if (!levers[15] &&
                ((cross_l.transform.position != cross_start_position_l) || ((x1l.x > -6.73f) && (x2l.x > -6.73f) && (x3l.x > -6.73f)) ||
                ((x4l == cross_start_position_l) && (x1l == start_position_l) && (x2l == start_position_l) && (x3l.x > -6.73f)) || // 4 1 2 in start pos
                ((x4l == cross_start_position_l) && (x1l == start_position_l) && (x2l.x > -6.73f) && (x3l.x > -6.73f)) || // 4 1 in start pos
                ((x4l == cross_start_position_l) && (x2l == start_position_l) && (x1l.x > -6.73f) && (x3l.x > -6.73f))))  // 4 2 in start pos
                {
                    x4l = Move_lb(cross_l, 1, 0, cross_l.transform.position.x, limit_position_xl, true);
                }
        if (cross_l.transform.position == cross_start_position_l) {
            StartCoroutine(Waiter(levers, 15));
        }
    }

    /* COROUTINES */

    IEnumerator Waiter(bool[] levers, int i)
    {
        levers[i] = true;
        yield return new WaitForSeconds(Random.Range(t0_await, t_await));
        levers[i] = false;
    }

    /* MOVEMENT */

    Vector3 Move_rt(GameObject item, int xvec, int yvec, float item_position, float limit_position, bool right)
    {// right and top movement
        item.transform.Translate(new Vector3(xvec, yvec).normalized * speed);
        if (item_position <= limit_position)
        {
            if (right) {
                ScaleAndStatUpdate(item, start_position_r);
            } else {
                ScaleAndStatUpdate(item, start_position_t);
            }
        }
        return item.transform.position;
    }

    Vector3 Move_lb(GameObject item, int xvec, int yvec, float item_position, float limit_position, bool left)
    {// left and bottom movement
        item.transform.Translate(new Vector3(xvec, yvec).normalized * speed);
        if (item_position >= limit_position)
        {
            if (left) {
                ScaleAndStatUpdate(item, start_position_l);
            } else {
                ScaleAndStatUpdate(item, start_position_b);
            }
        }
        return item.transform.position;
    }

    void ScaleAndStatUpdate(GameObject item, Vector3 start_position)
    {
        if (item.transform.localScale.x > 0.02f) { // smooth scaling
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, minscale, 0.15f);
        } else {
            item.transform.position = start_position;
            item.transform.localScale = originscale;
            if ((item != cross_t) && (item != cross_b) &&
               (item != cross_r) && (item != cross_l))
            {
                fails_num ++;
                if (fails_num > 9) {
                    if (fails_num > 99) {
                        fails.text = ": ......." + fails_num;
                    } else {
                        fails.text = ": ........" + fails_num;
                    }
                } else {
                    fails.text = ": ........." + fails_num;
                }
            }
        }
    }
}