using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed;
    public float changeSpeed = 0.01f;
    private float dir;
    public Vector2 direction;
    public GameObject n_1;
    public GameObject n_2;
    public GameObject n_3;
    public GameObject start;
    public GameObject R_01;
    public GameObject R_02;
    public GameObject R_03;
    public GameObject L_01;
    public GameObject L_02;
    public GameObject L_03;
    public GameObject R_W;
    public GameObject L_W;
    private int Right_Count = 0;
    private int Left_Count = 0;
 
    void n_11()
    {
        n_2.SetActive(false);
        n_1.SetActive(true);
    }
    void n_22()
    {
        n_3.SetActive(false);
        n_2.SetActive(true);
    }
    void n_33()
    {
        n_3.SetActive(true);
    }
    void go1()
    {
        n_1.SetActive(false);
        start.SetActive(true);
    }
    void go2()
    {
        start.SetActive(false);
    }
    

IEnumerator Coroutine()
{
    n_33();
	yield return new WaitForSeconds(0.8f);
    n_22();
    yield return new WaitForSeconds(0.8f);
    n_11();
    yield return new WaitForSeconds(0.8f);
    go1();
    yield return new WaitForSeconds(0.8f);
    go2();
    yield return new WaitForSeconds(0.8f);
    Play();
}

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine());
    }

    void Play()
    {
        dir = Random.Range(-1.1f, 1.1f);
        transform.position = new Vector2(0, 0);
        if (dir > 0)
        {
            direction = new Vector2(Random.Range(-0.5f, -1), Random.Range(0.5f, 1));
        }
        if (dir <= 0)
        {
            direction = new Vector2(Random.Range(0.5f, 1), Random.Range(0.5f, 1));
        }
        speed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = direction.normalized * speed;

        speed += Time.deltaTime * changeSpeed;

        if ((transform.position.x > 11) && (Left_Count == 0))
        {
            Left_Count = 1;
            R_01.SetActive(true);
            Play();
        }
        if ((transform.position.x > 11) && (Left_Count == 1))
        {
            Left_Count = 2;
            R_02.SetActive(true);
            Play();
        }
        if ((transform.position.x > 11) && (Left_Count == 2))
        {
            R_03.SetActive(true);
            R_W.SetActive(true);
            Invoke("EndGame", 2);
        }
        if ((transform.position.x < -11) && (Right_Count == 0))
        {
            Right_Count = 1;
            L_01.SetActive(true);
            Play();
        }
        if ((transform.position.x < -11) && (Right_Count == 1))
        {
            Right_Count = 2;
            L_02.SetActive(true);
            Play();
        }
        if ((transform.position.x < -11) && (Right_Count == 2))
        {
            L_03.SetActive(true);
            L_W.SetActive(true);
            Invoke("EndGame", 2);
        }
    }    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Player")) && (transform.position.x < 9.2f) && (transform.position.x > -9.2f))
        {
            direction.x = -direction.x;
        }
        if (col.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }
    }

    private void EndGame()
    {
        GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>().MenuOrBoard();
    }
}
