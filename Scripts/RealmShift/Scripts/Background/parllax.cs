using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parllax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parllaxEffect;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        startpos = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x ;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parllaxEffect));
        float dist = (cam.transform.position.x * parllaxEffect);
        transform.position = new Vector3(startpos + dist ,transform.position.y,transform.position.z);
        if(temp > startpos + length){startpos += length;}
        else if (temp<startpos-length){startpos -= length;}
    }
}
