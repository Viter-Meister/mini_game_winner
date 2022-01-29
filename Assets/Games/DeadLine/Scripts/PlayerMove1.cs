using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    public float speed = 0.1f;

    private Rigidbody _rb;

    //private LineRenderer line;
    //public List<Vector3> pointsList;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        //pointsList = new List<Vector3>();

        //line = GetComponent<LineRenderer>();
        //pointsList.Add(new Vector3(-9, -5, 0));
        //line.positionCount = 0;
        //line.SetPosition(pointsList.Count - 1, pointsList[pointsList.Count - 1]);
    }

    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("HorizontalDeadL1");

        float moveVertical = Input.GetAxis("VerticalDeadL1");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.Translate(movement * speed * Time.fixedDeltaTime);

        //pointsList.Add(transform.position);
        //line.positionCount = pointsList.Count;
        //line.SetPosition(pointsList.Count - 1, pointsList[pointsList.Count - 1]);
    }
}
