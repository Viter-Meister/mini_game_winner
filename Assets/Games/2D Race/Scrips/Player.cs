using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        Vector3 dir = new Vector3(move, 0, 0);
        transform.Translate(dir.normalized * Time.deltaTime * speed);
    }
}
