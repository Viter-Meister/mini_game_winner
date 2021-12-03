using UnityEngine;

public class TetrisBrick : MonoBehaviour
{
    const int Length = 4;
    public TetrisMain main;
    private bool[,] bricks = new bool[Length, Length];
    public bool[,] box;
    public GameObject block;
    private GameObject[] oldBlocks = new GameObject[Length];
    private bool sleep = false;
    public Color[] colors;
    private Color color;

    void Start()
    {
        int type = Random.Range(0, 7);
        switch (type)
        {
            case 0:
                bricks[0, 0] = true;
                bricks[0, 1] = true;
                bricks[0, 2] = true;
                bricks[0, 3] = true;
                break;
            case 1:
                bricks[0, 0] = true;
                bricks[0, 1] = true;
                bricks[1, 0] = true;
                bricks[1, 1] = true;
                break;
            case 2:
                bricks[0, 0] = true;
                bricks[1, 0] = true;
                bricks[1, 1] = true;
                bricks[1, 2] = true;
                break;
            case 3:
                bricks[0, 0] = true;
                bricks[0, 1] = true;
                bricks[0, 2] = true;
                bricks[1, 0] = true;
                break;
            case 4:
                bricks[0, 1] = true;
                bricks[0, 2] = true;
                bricks[1, 0] = true;
                bricks[1, 1] = true;
                break;
            case 5:
                bricks[0, 0] = true;
                bricks[0, 1] = true;
                bricks[1, 1] = true;
                bricks[1, 2] = true;
                break;
            case 6:
                bricks[0, 0] = true;
                bricks[0, 1] = true;
                bricks[0, 2] = true;
                bricks[1, 1] = true;
                break;
            default:
                break;
        }
        color = colors[Random.Range(0, colors.Length)];
        DrawBrick();
        Invoke(nameof(Movement), TetrisMain.speed);
    }

    public bool Assert(int leftright, int up, bool[,] element)
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        bool Rez = true;
        for (int i = 0; i < Length; i++)
            for (int j = 0; j < Length; j++)
                if (element[i, j] & box[x + i + 1 + leftright, y + j + 1 - up])
                    Rez = false;
        return Rez;
    }

    public void Movement()
    {
        bool isTrue = Assert(0, 1, bricks);
        if (isTrue)
            transform.position -= transform.up;

        if (Input.GetKey(KeyCode.RightArrow))
            if (Assert(1, 0, bricks))
            {
                transform.position += transform.right;
                isTrue = true;
            }
                
        if (Input.GetKey(KeyCode.LeftArrow))
           if (Assert(-1, 0, bricks))
            {
                transform.position -= transform.right;
                isTrue = true;
            }
                
        if (isTrue)
            Invoke(nameof(Movement), TetrisMain.speed);
        else
        {
            sleep = true;
            if (transform.position.y >= 19)
                main.GameIsOver();
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                    if (bricks[i, j])
                        box[x + i + 1, y + j + 1] = true;
            main.box = box;
            main.SpawnBrick();
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("TetrisRotate") && !sleep)
            Rotate();
    }

    private void Rotate()
    {
        int width = 0;
        int height = 0;
        for (int i = 0; i < Length; i++)
            for (int j = 0; j < Length; j++)
                if (bricks[i, j] == true)
                {
                    width = width < i ? i : width;
                    height = height < j ? j : height;
                }
        bool[,] newBricks = new bool[Length, Length];
        for (int i = 0; i <= height; i++)
            for (int j = 0; j <= width; j++)
                newBricks[i, j] = bricks[width - j, i];
        if (Assert(0, 0, newBricks))
        {
            bricks = newBricks;
            DrawBrick();
        }
    }

    private void DrawBrick()
    {
        if (oldBlocks[0] != null)
            for (int i = 0; i < Length; i++)
                Destroy(oldBlocks[i]);
        int k = 0;
        for (int i = 0; i < Length; i++)
            for (int j = 0; j < Length; j++)
                if (bricks[i, j])
                {
                    oldBlocks[k] = Instantiate(block, transform.position
                        + new Vector3(0.5f + i, 0.5f + j), transform.rotation);
                    oldBlocks[k].GetComponent<SpriteRenderer>().color = color;
                    oldBlocks[k].transform.parent = transform;
                    k++;
                }
    }
}
