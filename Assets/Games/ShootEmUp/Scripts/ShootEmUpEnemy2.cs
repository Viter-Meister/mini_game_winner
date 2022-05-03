using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmUpEnemy2 : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;

    public AudioSource hit;

    public Sprite hp2_3;
    public Sprite hp1_3;
    private sbyte hp = 2;
    private SpriteRenderer HPSpriteRenderer;

    private GameObject stats;
    private ShootEmUpStats Stats;
    private Hero Hero;

    void Start()
    {
        rb.velocity = transform.right * -1 * speed;
        HPSpriteRenderer = transform.Find("HP").GetComponent<SpriteRenderer>();
        stats = GameObject.Find("Stats");
    }

    void Update()
    {
        if (transform.position.x < -9f) {
            Destroy(gameObject);
            ShootEmUpStats Stats = stats.GetComponent<ShootEmUpStats>();
            Stats.RemoveLife();
        }
    }

    public void TakeDamage()
    {
        Sprite[] hpSprites = new Sprite[] {hp1_3, hp2_3};
        hp -= 1;
        hit.Play();

        if (hp < 0) {
            Destroy(gameObject);
            ShootEmUpStats Stats = stats.GetComponent<ShootEmUpStats>();
            Stats.AddKill();
        } else
            HPSpriteRenderer.sprite = hpSprites[hp];
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Hero Hero = hitInfo.GetComponent<Hero>();
        
        if (Hero != null) {
            Destroy(gameObject);
            ShootEmUpStats Stats = stats.GetComponent<ShootEmUpStats>();
            Stats.RemoveLife();
        }
    }
}
