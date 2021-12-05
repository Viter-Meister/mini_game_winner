using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines_mover : MonoBehaviour
{
    public float speed = 0.02f;
    
    // top
    public Vector2 start_position_t = new Vector2(-1.071f, 4.91f);
    public float limit_position_yt = 2.31f;
    public GameObject line1_t;
    public GameObject line2_t;
    public GameObject line3_t;
    public GameObject line4_t;

    // bottom
    public Vector2 start_position_b = new Vector2(-1.071f, -4.77f);
    public float limit_position_yb = -1.81f;
    public GameObject line1_b;
    public GameObject line2_b;
    public GameObject line3_b;
    public GameObject line4_b;

    // right
    public Vector2 start_position_r = new Vector2(4.9f, 0.37f);
    public float limit_position_xr = 1.29f;
    public GameObject line1_r;
    public GameObject line2_r;
    public GameObject line3_r;
    public GameObject line4_r;

    // left
    public Vector2 start_position_l = new Vector2(-7.221f, 0.37f);
    public float limit_position_xl = -3.175f;
    public GameObject line1_l;
    public GameObject line2_l;
    public GameObject line3_l;
    public GameObject line4_l;

    void Move_rt(GameObject line, int xvec, int yvec, float item_position, float limit_position, bool right)
    {// right and top movement
        line.transform.Translate(new Vector2(xvec, yvec).normalized * speed);
        if (item_position <= limit_position)
        {
            if (right) {
                line.transform.position = start_position_r;
            } else {
                line.transform.position = start_position_t;
            }
        }
    }

    void Move_lb(GameObject line, int xvec, int yvec, float item_position, float limit_position, bool left)
    {// left and bottom movement
        line.transform.Translate(new Vector2(xvec, yvec).normalized * speed);
        if (item_position >= limit_position)
        {   
            if (left) {
                line.transform.position = start_position_l;
            } else {
                line.transform.position = start_position_b;
            }
        }
    }

    void FixedUpdate()
    {   
        Move_rt(line1_t, 0, -1, line1_t.transform.position.y, limit_position_yt, false);
        Move_rt(line2_t, 0, -1, line2_t.transform.position.y, limit_position_yt, false);
        Move_rt(line3_t, 0, -1, line3_t.transform.position.y, limit_position_yt, false);
        Move_rt(line4_t, 0, -1, line4_t.transform.position.y, limit_position_yt, false);
        Move_lb(line1_b, 0, 1, line1_b.transform.position.y, limit_position_yb, false);
        Move_lb(line2_b, 0, 1, line2_b.transform.position.y, limit_position_yb, false);
        Move_lb(line3_b, 0, 1, line3_b.transform.position.y, limit_position_yb, false);
        Move_lb(line4_b, 0, 1, line4_b.transform.position.y, limit_position_yb, false);
        Move_rt(line1_r, -1, 0, line1_r.transform.position.x, limit_position_xr, true);
        Move_rt(line2_r, -1, 0, line2_r.transform.position.x, limit_position_xr, true);
        Move_rt(line3_r, -1, 0, line3_r.transform.position.x, limit_position_xr, true);
        Move_rt(line4_r, -1, 0, line4_r.transform.position.x, limit_position_xr, true);
        Move_lb(line1_l, 1, 0, line1_l.transform.position.x, limit_position_xl, true);
        Move_lb(line2_l, 1, 0, line2_l.transform.position.x, limit_position_xl, true);
        Move_lb(line3_l, 1, 0, line3_l.transform.position.x, limit_position_xl, true);
        Move_lb(line4_l, 1, 0, line4_l.transform.position.x, limit_position_xl, true);
    }
}