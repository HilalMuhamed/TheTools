using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed;
    void Start()
    {
    }

    void Update()
    {

        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector2.right*speed*Time.deltaTime);}
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(-Vector2.right*speed*Time.deltaTime);}
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector2.up*speed*Time.deltaTime);}
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(-Vector2.up*speed*Time.deltaTime);}
    }

}
