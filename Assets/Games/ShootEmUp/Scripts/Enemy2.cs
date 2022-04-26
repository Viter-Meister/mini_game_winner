using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;

    public Sprite hp2_3;
    public Sprite hp1_3;
    private sbyte hp = 2;
    private SpriteRenderer HPSpriteRenderer;

    void Start()
    {
        rb.velocity = transform.right * -1 * speed;
        HPSpriteRenderer = transform.Find("HP").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (transform.position.x < -9f)
            Destroy(gameObject);
    }

    public void TakeDamage()
    {
        Sprite[] hpSprites = new Sprite[] {hp1_3, hp2_3};

        hp -= 1;

        if (hp < 0)
            Destroy(gameObject);
        else
            HPSpriteRenderer.sprite = hpSprites[hp];
    }
}
