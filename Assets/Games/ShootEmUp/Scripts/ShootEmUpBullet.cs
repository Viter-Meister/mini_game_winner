using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmUpBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        if (transform.position.x > 9f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        ShootEmUpEnemy2 Enemy = hitInfo.GetComponent<ShootEmUpEnemy2>();
        
        if (Enemy != null) {
            Enemy.TakeDamage();
            Destroy(gameObject);
        }
    }
}