using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines_y_move : MonoBehaviour
{
    public float speed = 0.02f;

    public Vector2 start_position_t = new Vector2(-1.071f, 4.91f);
    public float limit_position_yt = 2.31f;
    public Vector2 start_position_b = new Vector2(-1.071f, -4.77f);
    public float limit_position_yb = -1.81f;
    public GameObject line1; public GameObject line2;
    public GameObject line3; public GameObject line4;
    public GameObject line5; public GameObject line6;
    public GameObject line7; public GameObject line8;

    void Move_t(GameObject line)
    { // top movement
        line.transform.Translate(new Vector2(0, -1).normalized * speed);
        if (line.transform.position.y <= limit_position_yt)
        {
            line.transform.position = start_position_t;
        }
    }
    
    void Move_b(GameObject line)
    { // bottom movement
        line.transform.Translate(new Vector2(0, 1).normalized * speed);
        if (line.transform.position.y >= limit_position_yb)
        {
            line.transform.position = start_position_b;
        }
    }

    void FixedUpdate()
    {   
        Move_t(line1);
        Move_t(line2);
        Move_t(line3);
        Move_t(line4);
        Move_b(line5);
        Move_b(line6);
        Move_b(line7);
        Move_b(line8);
    }
}