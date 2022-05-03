using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmUp_Bullet : MonoBehaviour
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
        ShootEmUp_Enemy Enemy = hitInfo.GetComponent<ShootEmUp_Enemy>();
        
        if (Enemy != null) {
            Enemy.TakeDamage();
            Destroy(gameObject);
        }
    }
}