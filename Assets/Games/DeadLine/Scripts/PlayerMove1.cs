using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    public float speed = 0.1f;

    public GameObject Trail;

    public bool Death = false;

    public AudioSource explosionAudio;

    public GameObject explosionEffect;

    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("HorizontalDeadL1");

        float moveVertical = Input.GetAxis("VerticalDeadL1");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trail2")
        {
            explosionAudio.Play();
            Instantiate(explosionEffect, gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Trail.SetActive(false);
            Death = true;
        }
    }
}
