using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    public float waittime;
    public int currentPointIndex;
    bool once;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public GameObject bulletFireParticle,sound1;
    public Transform gunpoint;
    void Update()
    {
        if(transform.position != patrolPoints[currentPointIndex].position){transform.position = Vector2.MoveTowards(transform.position,patrolPoints[currentPointIndex].position,speed * Time.deltaTime);}
        else
        {
            if(once == false)
            {
            once = true;
            StartCoroutine(Wait());
            }
        }
        if(timeBtwShots <= 0){
        Instantiate(sound1,gunpoint.position,Quaternion.identity);
        Instantiate(bulletFireParticle,gunpoint.position,Quaternion.identity);
        Instantiate(projectile,gunpoint.position,Quaternion.identity);
        timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waittime);
        if(currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex = currentPointIndex + 1;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }

}
