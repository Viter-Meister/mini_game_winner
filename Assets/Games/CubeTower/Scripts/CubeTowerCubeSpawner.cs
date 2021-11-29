using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeTowerCubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject StartCube;
    private GameObject LastCube;

    private int level = 0;
    private Vector3 pos1 = new Vector3(0, 0.5f, -7);
    private Vector3 pos2 = new Vector3(-7, 0.5f, 0);

    public bool isEnd = false;

    private void Start()
    {
        LastCube = StartCube;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isEnd)
        {
            LastCube.GetComponent<CubeTowerMovingCube>().Stop();
            if (!isEnd)
                SpawnCube();
        }
    }

    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);
        cube.GetComponent<CubeTowerMovingCube>().spawner = gameObject.GetComponent<CubeTowerCubeSpawner>();
        cube.GetComponent<CubeTowerMovingCube>().LastCube = LastCube.transform;
        cube.transform.localScale = LastCube.transform.localScale;
        cube.GetComponent<CubeTowerMovingCube>().moveSpeed += level;
        LastCube = cube;
        //transform.position = level % 2 == 0 ? pos1 : pos2;
        cube.transform.position = new Vector3
            (transform.position.x, transform.position.y + 0.5f * level, transform.position.z);
        //cube.transform.rotation = Quaternion.Euler(0, level % 2 == 0 ? 0 : 90, 0);
        level++;
    }

    public void End()
    {
        isEnd = true;
        Invoke("BackToMenu", 2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);
    }

    private void BackToMenu()
    {
        Debug.Log("Go to menu");
        //SceneManager.LoadScene("MainMenu");
    }
}
