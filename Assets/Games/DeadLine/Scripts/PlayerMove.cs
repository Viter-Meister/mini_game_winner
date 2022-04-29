using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public string Horizontal;
    public string Vertical;
    public string Tag1;
    public string Tag2;
    public string Tag3;

    public float speed = 0.1f;
    public GameObject SelfTrail;
    public GameObject OtherTrail;
    public bool Death = false;
    public AudioSource explosionAudio;
    public GameObject explosionEffect;

    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis(Horizontal);
        transform.Rotate(0, 0, -moveHorizontal * 5);
        transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag1)
        {
            explosionAudio.Play();
            Instantiate(explosionEffect, gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            SelfTrail.SetActive(false);
            OtherTrail.SetActive(false);
            Death = true;
        }

        if (collision.gameObject.tag == Tag2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * (-1));
            SelfTrail.GetComponent<LineRenderer>().positionCount = 0;
            SelfTrail.GetComponent<DrawTrail>().pointsList.Clear();
            SelfTrail.GetComponent<DrawTrail>().TrailLength = 0;
        }

        if (collision.gameObject.tag == Tag3)
        {
            transform.position = new Vector3(transform.position.x*(-1), transform.position.y);
            SelfTrail.GetComponent<LineRenderer>().positionCount = 0;
            SelfTrail.GetComponent<DrawTrail>().pointsList.Clear();
            SelfTrail.GetComponent<DrawTrail>().TrailLength = 0;
        }
    }
}
