using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float leftSpeed;
    public float upDownSpeed;
    private int randpos;
    void Start()
    {
        randpos = Random.Range(0,2); 
    }
    void FixedUpdate()
    {
        transform.position = transform.position + (Vector3.left*leftSpeed*Time.deltaTime);
        if(randpos==0)
        {transform.position = transform.position + (Vector3.up*upDownSpeed*Time.deltaTime);}
        else
        {transform.position = transform.position + (Vector3.down*upDownSpeed*Time.deltaTime);}    
    }
}
