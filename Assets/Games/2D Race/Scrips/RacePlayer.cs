using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePlayer : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        gameObject.GetComponent<Rigidbody>().WakeUp();
        float move = Input.GetAxisRaw("Horizontal");

        Vector3 dir = new Vector3(move, 0, 0);
        transform.Translate(dir.normalized * Time.deltaTime * speed);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }
}
