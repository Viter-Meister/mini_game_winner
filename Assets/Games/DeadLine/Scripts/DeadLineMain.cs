using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineMain : MonoBehaviour
{
    private bool Nofirst = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trail" && Nofirst)
        {
            Debug.Log("!");
            gameObject.SetActive(false);
        }

        Nofirst = true;
    }
}
