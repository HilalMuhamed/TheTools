using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public GameObject deathParticle1,deathParticle2;
    public GameObject sound1;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction =mousePos - transform.position;
        //Vector3 rotation = transform.position - mousePos;
        Instantiate(deathParticle1,transform.position,Quaternion.identity);
        Instantiate(deathParticle2,transform.position,Quaternion.identity);
        rb.velocity = new Vector2(direction.x,direction.y).normalized *force;
        //float rot = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
        //transform.rotation =Quaternion.Euler(0,0,rot +90);   
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,5f);
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
     if(hit.CompareTag("Enemy"))
     {
         Instantiate(sound1,transform.position,Quaternion.identity);
        Destroy(gameObject);
        }   
    }
}
