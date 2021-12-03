using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines_x_move : MonoBehaviour
{
    public float speed = 0.02f;

    // RIGHT
    public Vector2 start_position_r = new Vector2(4.9f, 0.37f);
    public float limit_position_xr = 1.29f;
    public GameObject line1_r;
    public GameObject line2_r;
    public GameObject line3_r;
    public GameObject line4_r;

    // LEFT
    public Vector2 start_position_l = new Vector2(-7.221f, 0.37f);
    public float limit_position_xl = -3.175f;
    public GameObject line1_l;
    public GameObject line2_l;
    public GameObject line3_l;
    public GameObject line4_l;

    void Move_r(GameObject line)
    { // right movement
        line.transform.Translate(new Vector2(-1, 0).normalized * speed);
        if (line.transform.position.x <= limit_position_xr)
        {
            line.transform.position = start_position_r;
        }
    }
    
    void Move_l(GameObject line)
    { // left movement
        line.transform.Translate(new Vector2(1, 0).normalized * speed);
        if (line.transform.position.x >= limit_position_xl)
        {
            line.transform.position = start_position_l;
        }
    }

    void FixedUpdate()
    {   
        Move_r(line1_r);
        Move_r(line2_r);
        Move_r(line3_r);
        Move_r(line4_r);
        Move_l(line1_l);
        Move_l(line2_l);
        Move_l(line3_l);
        Move_l(line4_l);
    }
}