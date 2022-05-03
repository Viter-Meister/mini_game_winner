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

        if (gameController.GetComponent<SpawnCars>().score == 150)
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            bump.Play();
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }
}
