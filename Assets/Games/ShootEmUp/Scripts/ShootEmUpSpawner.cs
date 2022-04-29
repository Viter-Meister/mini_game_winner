using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmUpSpawner : MonoBehaviour
{
    public float cooldownMin = 1.1f;
    public float cooldownMax = 5f;
    //public GameObject enemyPrefab_1;
    public GameObject enemyPrefab_2;
    //public GameObject enemyPrefab_3;

    void Start()
    {
        StartCoroutine(SpawnEnemy(enemyPrefab_2, cooldownMin, cooldownMax));
    }

    IEnumerator SpawnEnemy(GameObject enemyPrefab, float cooldownMin, float cooldownMax)
    {
        for(;;) {
            Instantiate(
                enemyPrefab,
                new Vector3(9.9f, Random.Range(-3.27f, 2.89f), 0),
                Quaternion.identity
            );

            yield return new WaitForSeconds(Random.Range(cooldownMin, cooldownMax));
        }
    }
}
