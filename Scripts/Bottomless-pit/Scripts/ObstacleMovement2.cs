using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement2 : MonoBehaviour
{
    public float ObstacleSpeed;
    void Start(){Destroy(gameObject,5f);}
    void FixedUpdate()
    {
        
        transform.position = transform.position + (Vector3.up *ObstacleSpeed*Time.deltaTime);
        
    }
}