using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MoveRoad : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject road;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -9f)
        {
            Instantiate(road, new Vector3(0, 13.85f, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
