using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{   
    public float speed = 2f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector3 mousePoint;
    private bool shootLever = true;

    void Update()
    {
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoint.z = 0;

        // movement
        if ((mousePoint.y > -4f) && (mousePoint.y < 3.7f))
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(-6.87f, mousePoint.y, 0),
                speed * Time.deltaTime
            );
        else if (mousePoint.y >= 3.7f)
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(-6.87f, 3.43f, 0),
                speed * Time.deltaTime
            );
        else
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(-6.87f, -4.21f, 0),
                speed * Time.deltaTime
            );
        
        // shoot
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Shoot();
        }
    }

    void Shoot()
    {
        if (shootLever) {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        shootLever = false;
        yield return new WaitForSeconds(0.5f);
        shootLever = true;
    }
}
