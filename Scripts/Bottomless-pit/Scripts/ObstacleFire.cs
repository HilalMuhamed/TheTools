using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFire : MonoBehaviour
{
    public float ObstacleSpeed;
    void Start(){transform.position = transform.position + new Vector3(-1,0,0);
    Destroy(gameObject,5f);}
    void FixedUpdate()
    {
        
        transform.position = transform.position + (Vector3.left *ObstacleSpeed*Time.deltaTime);
        transform.position = transform.position + (Vector3.up *(ObstacleSpeed-5)*Time.deltaTime);
        
    }
}