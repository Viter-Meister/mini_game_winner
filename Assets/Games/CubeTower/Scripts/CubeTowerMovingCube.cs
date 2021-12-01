using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTowerMovingCube : MonoBehaviour
{
    public CubeTowerCubeSpawner spawner;
    public Transform LastCube;
    public bool isStop;

    public float moveSpeed = 3;

    internal void Stop()
    {
        if (isStop)
            return;

        isStop = true;
        SplitCube();
    }

    private void SplitCubeXorZ(float pos1, float pos2, float scale1, float scale2)
    {
        float left1 = pos1 - scale1 / 2;
        float left2 = pos2 - scale2 / 2;
        float right1 = pos1 + scale1 / 2;
        float right2 = pos2 + scale2 / 2;

        if (left2 > right1 || right2 < left1)
        {
            spawner.Score--;

            spawner.isEnd = true;

            spawner.End();

            Destroy(gameObject);
            return;
        }

        float size = pos1 < pos2 ? 
            Mathf.Abs(right1 - left2) : Mathf.Abs(right2 - left1);

        SpawnDropCube(pos1 < pos2 ? pos1 - size / 2 : pos1 + size / 2, scale1 - size);

        transform.position = new Vector3(transform.position.x, transform.position.y,
            (pos1 < pos2 ? left2 : left1) + size / 2);

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, size);
    }

    private void SplitCube()
    {
        SplitCubeXorZ(transform.position.z, LastCube.position.z,
            transform.localScale.z, LastCube.localScale.z);
    }

    private void SpawnDropCube(float fallingBlockPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockPosition);
        cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
        cube.AddComponent<Rigidbody>();
        Destroy(cube.gameObject, 2);
    }

    private void Update()
    {
        if (!isStop)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}
