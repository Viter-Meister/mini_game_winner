using UnityEngine.SceneManagement;
using UnityEngine;

public class TetrisMain : MonoBehaviour
{
    public TextMesh Text;
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
        speed = 0.2f + Input.GetAxis("TetrisDown") / 8;

    }

    public void SpawnBrick()
    {
        CheckRemoveLayers();
        GameObject Brick = Instantiate(Bricks, spawn.position, transform.rotation);
        Brick.GetComponent<TetrisBrick>().box = box;
        Brick.GetComponent<TetrisBrick>().main = gameObject.GetComponent<TetrisMain>();
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
        Text.text = (int.Parse(Text.text) + 1).ToString();
        CheckRemoveLayers();
    }

    public void GameIsOver()
    {
        BasicValues bv = GameObject.Find("NotDestroy(Clone)").GetComponent<BasicValues>();

        int x = int.Parse(Text.text);

        if (x > 3)
        {
            if (x <= 5)
                bv.ChooseBonus(1);
            if (x <= 6)
                bv.ChooseBonus(2);
            if (x <= 7)
                bv.ChooseBonus(3);
            if (x <= 8)
                bv.ChooseBonus(4);
            if (x <= 9 || bv.playersCount == 1)
                bv.ChooseBonus(5);
            else
                bv.ChooseBonus(6);
        }

        bv.MenuOrBoard();
    }
}
