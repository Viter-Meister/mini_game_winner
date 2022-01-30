using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public float speed = 0.1f;

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
}
