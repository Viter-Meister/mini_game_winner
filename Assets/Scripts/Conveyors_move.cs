using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyors_move : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed);
        if (this.gameObject.transform.position.x <= 1.28)
        {
            transform.position = new Vector3(4.9f, 0.37f, 0);
        };
    }
}
