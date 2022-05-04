using TMPro;
using UnityEngine;


public class RightPlayer : MonoBehaviour
{
    [SerializeField] GameObject Life_1;
    [SerializeField] GameObject Life_2;
    [SerializeField] GameObject Life_3;
    [SerializeField] GameObject Life_4;
    [SerializeField] GameObject Life_5;
    [SerializeField] GameObject Canvas;

    public Rigidbody Rb;

    public float RunSpeed;
    public float SideSpeed;
    public float JumpForse;
    

    protected bool rightMove;
    protected bool leftMove;
    protected bool jump;

    public TMP_Text scoreText;
    public int score;
    private int distance;

    // Start is called before the first frame update
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody>();
        RunSpeed = 8f;
        SideSpeed = 6f;
        JumpForse = 14f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            leftMove = true;
        else leftMove = false;

        if (Input.GetKey(KeyCode.RightArrow))
            rightMove = true;
        else rightMove = false;

        if (Input.GetKey(KeyCode.UpArrow))
            jump = true;

        distance += 1;
        if (distance % 30 == 0)
        {
            score += 1;
            scoreText.text = score.ToString();
        }

        if (score == 150)
            gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Rb.MovePosition(transform.position + Vector3.forward * RunSpeed * Time.deltaTime);

        if (rightMove)
        {
            Rb.MovePosition(transform.position + Vector3.right * RunSpeed * Time.deltaTime);
            new WaitForSeconds(0.01f);
            rightMove = false;
        }

        if (leftMove)
        {
            Rb.MovePosition(transform.position + Vector3.left * SideSpeed * Time.deltaTime);
            new WaitForSeconds(0.001f);
            leftMove = false;
        }

        if (jump && this.transform.position.y < 0.76)
        {
            Rb.AddForce(Vector3.up * JumpForse, ForceMode.Impulse);
            jump = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            gameObject.SetActive(false);
        }
    }

    void Countdown()
    {

    }
}
