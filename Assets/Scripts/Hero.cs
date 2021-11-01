using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{   
    public Sprite cat_sits;
    public Sprite cat_with_box_lr;
    public Sprite cat_with_box_up;
    public Sprite cat_with_box_down;

    void Update()
    {   
        /* MOVEMENT */
        if (Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.LeftArrow))
        { // left
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_lr;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector3(-2.1f, 0.13f, 0);
        }
        else if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.DownArrow))
        { // down
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_down;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(-1.73f, -1.47f, 0);
        }
        else if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.UpArrow))
        { // up
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_up;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(-0.36f, 1.44f, 0);
        }
        else if (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow))
        { // right
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_with_box_lr;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(0.23f, 0.09f, 0);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cat_sits;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(-0.99f, 0.22f, 0);
        }
    }
}
