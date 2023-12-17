using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
 {
    public float ObstacleSpeed;
    void FixedUpdate()
    {
        
        transform.position = transform.position + (Vector3.left*ObstacleSpeed*Time.deltaTime);
        
    }
}
