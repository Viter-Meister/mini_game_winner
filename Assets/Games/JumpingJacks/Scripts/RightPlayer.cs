using System.Collections;
using System;
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

    // Start is called before the first frame update
    void Start()
    {
        RunSpeed = 6f;
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

        if (Rb.transform.position.z > 100)
            RunSpeed = 7f;
        if (Rb.transform.position.z > 280)
            RunSpeed = 6f;
        if (Rb.transform.position.z > 1230)
            ;
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

    void Countdown()
    {

    }
}
