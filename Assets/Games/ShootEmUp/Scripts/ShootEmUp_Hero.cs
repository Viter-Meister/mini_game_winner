using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmUp_Hero : MonoBehaviour
{   
    public float cooldown = 0.5f;
    public float speed = 2f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector3 mousePoint;
    private bool shootLever = true;
    public AudioSource blaster;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoint.z = 0;

        // movement
        if ((mousePoint.y > -4f) && (mousePoint.y < 3.59f))
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(-6.87f, mousePoint.y, 0),
                speed * Time.deltaTime
            );
        else if (mousePoint.y >= 3.47f)
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(-6.87f, 3.51f, 0),
                speed * Time.deltaTime
            );
        else
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(-6.87f, -4.17f, 0),
                speed * Time.deltaTime
            );
        
        // shooting
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown("space")) {
            blaster.Play();
            Shoot();
        }
    }

    void Shoot()
    {
        if (shootLever) {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(Cooldown(cooldown));
        }
    }

    IEnumerator Cooldown(float time)
    {
        shootLever = false;
        yield return new WaitForSeconds(time);
        shootLever = true;
    }
}
