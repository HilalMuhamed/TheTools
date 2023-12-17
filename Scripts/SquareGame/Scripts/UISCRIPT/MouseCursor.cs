using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public GameObject clickEffect;
   
    void Start()
    {
        Cursor.visible =false;
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position =cursorPos;
        if(Input.GetMouseButtonDown(0)){Instantiate(clickEffect,transform.position,Quaternion.identity);}
    }
}
