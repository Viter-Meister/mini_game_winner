using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{   
    public Sprite cat_sits;
    public Sprite cat_with_box_lr;
    public Sprite cat_with_box_up;
    public Sprite cat_with_box_down;

    public Vector3 start_position_r        = new Vector3(5.45f, 0.6f, 0.0f);
    public Vector3 cross_start_position_r  = new Vector3(5.45f, 0.55f, 0.0f);
    public Vector3 start_position_l        = new Vector3(-7.8f, 0.6f, 0.0f);
    public Vector3 cross_start_position_l  = new Vector3(-7.8f, 0.55f, 0.0f);
    public Vector3 start_position_t  = new Vector3(-1.07f, 5.16f, 0.0f);
    public Vector3 start_position_b  = new Vector3(-1.07f, -5.12f, 0.0f);

    GameObject love1_l; GameObject love2_l; GameObject love3_l; GameObject cross_l;
    GameObject love1_r; GameObject love2_r; GameObject love3_r; GameObject cross_r;
    GameObject love1_t; GameObject love2_t; GameObject love3_t; GameObject cross_t;
    GameObject love1_b; GameObject love2_b; GameObject love3_b; GameObject cross_b;

    Vector3 originscale = new Vector3(0.6186985f, 0.6186985f, 0.0f);

    public Text loves; int loves_num;
    // public Text bonus1; int bonus1_num;
    // public Text bonus2; int bonus2_num;
    public Text bads; int bads_num;

    void Start()
    {
        love1_r = GameObject.Find("right_LOVE");    love1_l = GameObject.Find("left_LOVE");
        love2_r = GameObject.Find("right_LOVE_1");  love2_l = GameObject.Find("left_LOVE_1");
        love3_r = GameObject.Find("right_LOVE_2");  love3_l = GameObject.Find("left_LOVE_2");
        cross_r = GameObject.Find("right_CROSS");   cross_l = GameObject.Find("left_CROSS");

        love1_t = GameObject.Find("top_LOVE");      love1_b = GameObject.Find("bottom_LOVE");
        love2_t = GameObject.Find("top_LOVE_1");    love2_b = GameObject.Find("bottom_LOVE_1");
        love3_t = GameObject.Find("top_LOVE_2");    love3_b = GameObject.Find("bottom_LOVE_2");
        cross_t = GameObject.Find("top_CROSS");     cross_b = GameObject.Find("bottom_CROSS");
    }

    void Update()
    {   
        /* MOVEMENT AND CATHING ITEMS */

        if (Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.LeftArrow))
        {// left
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_lr;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(-2.1f, 0.13f);
            
            WasCatched_lb(love1_l, love1_l.transform.position.x, start_position_l, -3.525f);
            WasCatched_lb(love2_l, love2_l.transform.position.x, start_position_l, -3.525f);
            WasCatched_lb(love3_l, love3_l.transform.position.x, start_position_l, -3.525f);
            WasCatched_lb(cross_l, cross_l.transform.position.x, cross_start_position_l, -3.5f);
        }
        else if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.DownArrow))
        {// bottom
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_down;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector2(-1.73f, -1.47f);

            WasCatched_lb(love1_b, love1_b.transform.position.y, start_position_b, -2.15f);
            WasCatched_lb(love2_b, love2_b.transform.position.y, start_position_b, -2.15f);
            WasCatched_lb(love3_b, love3_b.transform.position.y, start_position_b, -2.15f);
            WasCatched_lb(cross_b, cross_b.transform.position.y, start_position_b, -2.12f);
        }
        else if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.UpArrow))
        {// top
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_up;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector2(-0.36f, 1.71f);

            WasCatched_rt(love1_t, love1_t.transform.position.y, start_position_t, 2.62f);
            WasCatched_rt(love2_t, love2_t.transform.position.y, start_position_t, 2.62f);
            WasCatched_rt(love3_t, love3_t.transform.position.y, start_position_t, 2.62f);
            WasCatched_rt(cross_t, cross_t.transform.position.y, start_position_t, 2.58f);
        }
        else if (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow))
        {// right
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_lr;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector2(0.23f, 0.09f);

            WasCatched_rt(love1_r, love1_r.transform.position.x, start_position_r, 1.622f);
            WasCatched_rt(love2_r, love2_r.transform.position.x, start_position_r, 1.622f);
            WasCatched_rt(love3_r, love3_r.transform.position.x, start_position_r, 1.622f);
            WasCatched_rt(cross_r, cross_r.transform.position.x, cross_start_position_r, 1.59f);
        }
        else
        {// start position
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_sits;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector2(-1f, 0.23f);
        }
    }

    void WasCatched_lb(GameObject item, float item_position, Vector3 start_position, float limit_position)
    {// left and bottom movement
        if (item_position > limit_position) {
            item.transform.position = start_position;
            item.transform.localScale = originscale;
            StatUpdate(item);
        }
    }

    void WasCatched_rt(GameObject item, float item_position, Vector3 start_position, float limit_position)
    {// right and top movement
        if (item_position < limit_position) {
            item.transform.position = start_position;
            item.transform.localScale = originscale;
            StatUpdate(item);
        }
    }

    void StatUpdate(GameObject item)
    {
        if ((item == cross_t) || (item == cross_b) || (item == cross_r) || (item == cross_l)) {
            bads_num ++;
            if (bads_num > 9) {
                if (bads_num > 99) {
                    bads.text = ": ........" + bads_num;
                } else {
                    bads.text = ": ........." + bads_num;
                }
            } else {
                bads.text = ": .........." + bads_num;
            }
        } else {
            loves_num ++;
            if (loves_num > 9) {
                if (loves_num > 99) {
                    loves.text = ": ......." + loves_num;
                } else {
                    loves.text = ": ........" + loves_num;
                }
            } else {
                loves.text = ": ........." + loves_num;
            }
        }
    }
}
