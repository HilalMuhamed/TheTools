using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speed;
    void FixedUpdate()
    {
        
        transform.position = (Vector2)transform.position + new Vector2(0f,Input.GetAxis("Vertical")*speed*Time.deltaTime);}
}
