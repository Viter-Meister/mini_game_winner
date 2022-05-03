using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmUp_Spawner : MonoBehaviour
{
    public int enemiesCountWave1 = 10;
    public int enemiesCountWave2 = 4;

    public GameObject enemyPrefab_1;
    public GameObject enemyPrefab_2;
    public GameObject enemyPrefab_3;

    void Start()
    {
        StartCoroutine(Spawning());
        StartCoroutine(SpawningBackgroundEnemies());
    }

    IEnumerator Spawning()
    {
        // wave 1
        for(int i = 0; i < enemiesCountWave1; i++) {
            SpawnEnemy(enemyPrefab_2, 9.9f, -3.27f, 2.89f);
            yield return new WaitForSeconds(Random.Range(1.2f, 5f));
        }
        // wave 2
        for(int i = 0; i < enemiesCountWave2; i++) {
            SpawnEnemy(enemyPrefab_3, 10.45f, -2.42f, 2.31f);
            yield return new WaitForSeconds(Random.Range(4f, 5f));
        }
    }

    IEnumerator SpawningBackgroundEnemies()
    {
        for(;;) {
            SpawnEnemy(enemyPrefab_1, 9.75f, -3.84f, 3.64f);
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }

    void SpawnEnemy(GameObject enemyPrefab, float X, float minY, float maxY)
    {
        Instantiate(enemyPrefab,
                    new Vector3(X, Random.Range(minY, maxY), 0),
                    Quaternion.identity);
    }
}
