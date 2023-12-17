using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float offset;
    private float timeBtwShots;
    public float startTimBtwShots;
    
    public GameObject BulletEffect;


    
    
 
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        
    }

    void Shoot()
    {
        Instantiate(BulletEffect, firePoint.position, Quaternion.identity);
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        timeBtwShots = startTimBtwShots;
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Debug.Log("Hello");
    }
}
