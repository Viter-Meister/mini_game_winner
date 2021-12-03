using UnityEngine.SceneManagement;
using UnityEngine;

public class Main : MonoBehaviour
{
    const int Length1 = 15;
    const int Length2 = 24;
    public bool[,] box = new bool[Length1, Length2];
    public GameObject Bricks;
    public Transform spawn;
    public static float speed = 0.2f;

    private void Start()
    {
        for (int i = 0; i < Length1; i++)
            box[i, 0] = true;
        for (int i = 0; i < Length2; i++)
        {
            box[0, i] = true;
            box[11, i] = true;
        }

        SpawnBrick();
    }

    private void Update()
    {
        speed = 0.2f + Input.GetAxis("Vertical2") / 8;
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void SpawnBrick()
    {
        CheckRemoveLayers();
        GameObject Brick = Instantiate(Bricks, spawn.position, transform.rotation);
        Brick.GetComponent<Brick>().box = box;
        Brick.GetComponent<Brick>().main = gameObject.GetComponent<Main>();
    }

    private void CheckRemoveLayers()
    {
        int layer = CheckLayers();
        if (layer != -1)
            RemoveLayer(layer);
    }

    private int CheckLayers()
    {
        for (int i = 1; i < Length2 - 3; i++)
        {
            bool isFull = true;
            for (int j = 1; j <= 10; j++)
                if (!box[j, i])
                    isFull = false;
            if (isFull)
                return i - 1;
        }
        return -1;
    }

    private void RemoveLayer(int layer)
    {
        for (int i = 1; i < Length1 - 4; i++)
            for (int j = layer + 1; j < Length2 - 3; j++)
                box[i, j] = box[i, j + 1];
        var blocks = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < blocks.Length; i++)
            if (Mathf.Abs(blocks[i].transform.position.y - 0.5f - layer) < 0.1f)
                Destroy(blocks[i]);
            else if (blocks[i].transform.position.y > 0.5f + layer)
                blocks[i].transform.position -= transform.up;
        var bricks = GameObject.FindGameObjectsWithTag("Brick");
        for (int i = 0; i < bricks.Length; i++)
            if (bricks[i].transform.childCount == 0)
                Destroy(bricks[i]);
        CheckRemoveLayers();
    }

    public void GameIsOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
