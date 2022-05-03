using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmUp_Enemy : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;

    public Sprite hp1_2 = null;
    public Sprite hp2_3 = null;
    public Sprite hp1_3 = null;
    public Sprite hp4_5 = null;
    public Sprite hp3_5 = null;
    public Sprite hp2_5 = null;
    public Sprite hp1_5 = null;
    public sbyte  hp = 2;
    private Sprite[] hpSprites;
    private SpriteRenderer hpSpriteRenderer;
    private SpriteRenderer shipSpriteRenderer;

    private GameObject stats;
    private ShootEmUp_Stats Stats;
    private ShootEmUp_Hero Hero;

    void Start()
    {
        rb.velocity = transform.right * -1 * speed;
        hpSpriteRenderer   = transform.Find("HP").GetComponent<SpriteRenderer>();
        shipSpriteRenderer = transform.Find("Ship").GetComponent<SpriteRenderer>();
        stats = GameObject.Find("Stats");

        if (hp == 4)
            hpSprites = new Sprite[] {hp1_5, hp2_5, hp3_5, hp4_5};
        else if (hp == 2)
            hpSprites = new Sprite[] {hp1_3, hp2_3};
        else if (hp == 1)
            hpSprites = new Sprite[] {hp1_2};
    }

    void Update()
    {
        if (transform.position.x < -9f) {
            Destroy(gameObject);
            Stats = stats.GetComponent<ShootEmUp_Stats>();
            Stats.RemoveLife();
        }
    }

    public void TakeDamage()
    {
        hp -= 1;

        if (hp < 0) {
            rb.velocity = new Vector2(0, 0);
            StartCoroutine(Die(0.01f));
        } else
            hpSpriteRenderer.sprite = hpSprites[hp];
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Hero = hitInfo.GetComponent<ShootEmUp_Hero>();
        
        if (Hero != null) {
            StartCoroutine(Die(0.01f));
            Stats = stats.GetComponent<ShootEmUp_Stats>();
            Stats.RemoveLife();
        }
    }

    IEnumerator Die(float time)
    {
        Destroy(GetComponent<PolygonCollider2D>());
        for (int i = 20; i > 0; i--) {
            yield return new WaitForSeconds(time);
            shipSpriteRenderer.color = new Color(1f,1f,1f,0.05f*i);
        }
        Destroy(gameObject);
        Stats = stats.GetComponent<ShootEmUp_Stats>();
        Stats.AddKill();
    }
}
