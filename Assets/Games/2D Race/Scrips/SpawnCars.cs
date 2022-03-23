using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public GameObject[] cars;
    private float[] positions = { -2.91f, -1f, 0.97f, 2.91f };

    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while(true)
        {
            Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(positions[Random.Range(0, positions.Length)], 8.5f, 0), Quaternion.Euler(new Vector3(90, 180, 0)));
            yield return new WaitForSeconds(3f);
        }
    }
}
