using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    private float timer;
    public float timeBetweenFiring;
    private bool canFire = true;
    public GameObject bulletFireParticle;
    public GameObject bulletFireParticle2;
    public GameObject sound1;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float roatz = Mathf.Atan2(rotation.y,rotation.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,roatz);
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
        CameraShaker.Instance.ShakeOnce(1f, 0.7f, 0.1f, 0.1f);
        Instantiate(sound1,bulletTransform.position,Quaternion.identity);
        Instantiate(bulletFireParticle,bulletTransform.position,Quaternion.identity);
        Instantiate(bulletFireParticle2,bulletTransform.position,Quaternion.identity);
        Instantiate(bullet,bulletTransform.position,Quaternion.identity);

    }
}
}
