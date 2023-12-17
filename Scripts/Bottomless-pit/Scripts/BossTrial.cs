using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrial: MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    public float waittime;
    public int currentPointIndex;
    bool once;
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