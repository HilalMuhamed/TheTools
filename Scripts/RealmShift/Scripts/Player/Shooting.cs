using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool isFacingRight;
    private float horizontal;
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    private float timer;
    public float timeBetweenFiring;
    private bool canFire = true;
    public float offset =90f;

    public GameObject bulletFireParticle,sound1;
    
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if(isFacingRight)
        {
        Vector3 rotation = mousePos - transform.position;
        float roatz = Mathf.Atan2(rotation.y,rotation.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,roatz + offset);
        }
        else
        {
        Vector3 rotation = (mousePos - transform.position);
        float roatz = Mathf.Atan2(rotation.y,rotation.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,roatz + offset);
        }
 
    if(!canFire)
    {
        timer +=Time.deltaTime;
        if(timer>timeBetweenFiring)
        {
            canFire =true;
            timer =0;
        }
    }
    
    if(Input.GetMouseButton(0) && canFire)
    {
        canFire =false;
        Instantiate(sound1,bulletTransform.position,Quaternion.identity);
        Instantiate(bulletFireParticle,bulletTransform.position,Quaternion.identity);
        Instantiate(bullet,bulletTransform.position,Quaternion.identity);
    }
    }
}
