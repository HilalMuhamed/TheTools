using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parllax1 : MonoBehaviour
{

    public float speed;
    public float endX;
    public float startX;
    public GameObject cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        transform.Translate(Vector2.left *speed*Time.deltaTime);
        if(transform.position.x + cam.transform.position.x <= endX + cam.transform.position.x )
        {
            Vector2 pos = new Vector2(startX +cam.transform.position.x ,transform.position.y);
            transform.position = pos;
        }
    }
}
