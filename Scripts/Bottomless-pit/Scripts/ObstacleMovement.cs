using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float ObstacleSpeed;
    void FixedUpdate()
    {
        
        transform.position = transform.position + (Vector3.up *ObstacleSpeed*Time.deltaTime);
        
    }
}
