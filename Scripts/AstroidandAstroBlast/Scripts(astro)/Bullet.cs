using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletpower = 10f;
    public float shootingtime =1f;
    private float timer;
    public GameObject deathparticle1,deathparticle2,sound1;

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)&& timer >= shootingtime)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;
            Instantiate(sound1,transform.position,Quaternion.identity);
            Instantiate(deathparticle1,transform.position,Quaternion.identity);
            Instantiate(deathparticle2,transform.position,Quaternion.identity);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = direction * bulletpower;
            timer = 0f;
        }
    }
}
