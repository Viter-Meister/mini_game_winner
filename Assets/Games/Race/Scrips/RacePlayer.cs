using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePlayer : MonoBehaviour
{
    public float speed = 4f;

    public AudioSource bump;

    public GameObject gameController;

    private void Start()
    {
        bump = gameController.GetComponent<AudioSource>();
    }
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().WakeUp();
        float move = Input.GetAxisRaw("Horizontal");

        Vector3 dir = new Vector3(move, 0, 0);
        transform.Translate(dir.normalized * Time.deltaTime * speed);

        if (gameController.GetComponent<SpawnCars>().score == 40)
        {
            GameIsOver();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            bump.Play();
            GameIsOver();
        }
    }

    public void GameIsOver()
    {
        BasicValues bv = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();

        int x = gameController.GetComponent<SpawnCars>().score;

        if (x > 10)
        {
            if (x <= 15)
                bv.ChooseBonus(1);
            if (x <= 20)
                bv.ChooseBonus(2);
            if (x <= 25)
                bv.ChooseBonus(3);
            if (x <= 30)
                bv.ChooseBonus(4);
            if (x <= 35 || bv.playersCount == 1)
                bv.ChooseBonus(5);
            else
                bv.ChooseBonus(6);
        }

        bv.MenuOrBoard();
    }
}