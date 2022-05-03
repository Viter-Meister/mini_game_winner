using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmUp_BackgroundDynamic : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * -1 * speed;
    }

    void Update()
    {
        if (transform.position.x <= -24.151f)
            transform.position = new Vector3(24.16296f, 0, 0);
    }
}
