using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipMove : MonoBehaviour
{
    public float pipeSpeed;

    void FixedUpdate()
    {
        
        transform.position = transform.position + (Vector3.left *pipeSpeed*Time.deltaTime);
        Destroy(gameObject,10f);
        
    }
}
