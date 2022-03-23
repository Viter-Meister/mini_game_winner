using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public GameObject End;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        Vector3 dir = new Vector3(move, 0, 0);
        transform.Translate(dir.normalized * Time.deltaTime * speed);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
            Instantiate(End, new Vector3(-0.7593835f, 3.565657f, -2), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
}
