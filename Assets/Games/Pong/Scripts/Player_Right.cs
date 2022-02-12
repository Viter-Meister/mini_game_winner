using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Right : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        if ((Input.GetKey(KeyCode.UpArrow)) && (this.transform.position.y < 2.79))
        {
            direction = Vector2.up * speed;
        }

        if ((Input.GetKey(KeyCode.DownArrow)) && (this.transform.position.y > -3.843))
        {
            direction = Vector2.down * speed;
        }
        rigidbody.velocity = direction * speed;
    }
}