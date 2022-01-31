using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public float speed = 0.1f;

    public GameObject Trail;

    public bool Death = false;

    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("HorizontalDeadL2");

        float moveVertical = Input.GetAxis("VerticalDeadL2");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trail1")
        {
            gameObject.SetActive(false);
            Trail.SetActive(false);
            Death = true;
        }
    }
}
