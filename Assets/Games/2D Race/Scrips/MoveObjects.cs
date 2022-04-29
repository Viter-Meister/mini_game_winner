using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.y < -6.5)
        {
            Destroy(gameObject);
        }
    }
}
