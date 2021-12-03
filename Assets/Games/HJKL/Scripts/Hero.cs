using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{   
    public Sprite cat_sits;
    public Sprite cat_with_box_lr;
    public Sprite cat_with_box_up;
    public Sprite cat_with_box_down;

    public Vector2 start_position_l        = new Vector2(-7.75f, 0.59f);
    public Vector2 cross_start_position_l  = new Vector2(-7.75f, 0.55f);
    public Vector2 start_position_r        = new Vector2(5.47f, 0.59f);
    public Vector2 cross_start_position_r  = new Vector2(5.47f, 0.55f);
    public Vector2 start_position_t  = new Vector2(-1.07f, 5.16f);
    public Vector2 start_position_b  = new Vector2(-1.07f, -5.12f);
    GameObject love1_l; GameObject love2_l; GameObject love3_l; GameObject cross_l;
    GameObject love1_r; GameObject love2_r; GameObject love3_r; GameObject cross_r;
    GameObject love1_t; GameObject love2_t; GameObject love3_t; GameObject cross_t;
    GameObject love1_b; GameObject love2_b; GameObject love3_b; GameObject cross_b;

    void Start()
    {
        love1_l = GameObject.Find("left_LOVE");
        love2_l = GameObject.Find("left_LOVE_1");
        love3_l = GameObject.Find("left_LOVE_2");
        cross_l = GameObject.Find("left_CROSS");

        love1_r = GameObject.Find("right_LOVE");
        love2_r = GameObject.Find("right_LOVE_1");
        love3_r = GameObject.Find("right_LOVE_2");
        cross_r = GameObject.Find("right_CROSS");

        love1_t = GameObject.Find("top_LOVE");
        love2_t = GameObject.Find("top_LOVE_1");
        love3_t = GameObject.Find("top_LOVE_2");
        cross_t = GameObject.Find("top_CROSS");

        love1_b = GameObject.Find("bottom_LOVE");
        love2_b = GameObject.Find("bottom_LOVE_1");
        love3_b = GameObject.Find("bottom_LOVE_2");
        cross_b = GameObject.Find("bottom_CROSS");
    }

    void Update()
    {   
        /* MOVEMENT AND CATHING */
        if (Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.LeftArrow))
        {// left
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_lr;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector3(-2.1f, 0.13f, 0);
            
            if (love1_l.transform.position.x > -3.525f) {   
                love1_l.transform.position = start_position_l;
                print("left!");
            }
            else if (love2_l.transform.position.x > -3.525f) {   
                love2_l.transform.position = start_position_l;
                print("left!");
            }
            else if (love3_l.transform.position.x > -3.525f) {   
                love3_l.transform.position = start_position_l;
                print("left!");
            }
            else if (cross_l.transform.position.x > -3.5) {   
                cross_l.transform.position = cross_start_position_l;
                print("BAD left!");
            }
        }
        else if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.DownArrow))
        {// down
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_down;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(-1.73f, -1.47f, 0);

            if (love1_b.transform.position.y > -2.11f) {   
                love1_b.transform.position = start_position_b;
                print("bottom!");
            }
            else if (love2_b.transform.position.y > -2.11f) {   
                love2_b.transform.position = start_position_b;
                print("bottom!");
            }
            else if (love3_b.transform.position.y > -2.11f) {   
                love3_b.transform.position = start_position_b;
                print("bottom!");
            }
            else if (cross_b.transform.position.y > -2.08f) {   
                cross_b.transform.position = start_position_b;
                print("BAD bottom!");
            }
        }
        else if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.UpArrow))
        {// up
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_up;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(-0.36f, 1.44f, 0);

            if (love1_t.transform.position.y < -2.34f) {   
                love1_t.transform.position = start_position_t;
                print("top!");
            }
            else if (love2_t.transform.position.y < -2.34f) {   
                love2_t.transform.position = start_position_t;
                print("top!");
            }
            else if (love3_t.transform.position.y < -2.34f) {   
                love3_t.transform.position = start_position_t;
                print("top!");
            }
            else if (cross_t.transform.position.y < -2.333f) {   
                cross_t.transform.position = start_position_t;
                print("BAD top!");
            }
        }
        else if (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow))
        {// right
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_lr;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(0.23f, 0.09f, 0);

            if (love1_r.transform.position.x < 1.622f) {   
                love1_r.transform.position = start_position_r;
                print("right!");
            }
            else if (love2_r.transform.position.x < 1.622f) {   
                love2_r.transform.position = start_position_r;
                print("right!");
            }
            else if (love3_r.transform.position.x < 1.622f) {   
                love3_r.transform.position = start_position_r;
                print("right!");
            }
            else if (cross_r.transform.position.x < 1.59) {   
                cross_r.transform.position = cross_start_position_r;
                print("BAD right!");
            }
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_sits;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(-1f, 0.23f, 0);
        }
    }
}
