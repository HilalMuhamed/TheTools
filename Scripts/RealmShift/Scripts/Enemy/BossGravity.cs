using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timer = 0f;
    public float toggleInterval = 15f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= toggleInterval)
        {
            ToggleGravity();
            timer = 0f;
        }
    }

    private void ToggleGravity()
    {
        if(rb.gravityScale == 1f){rb.gravityScale =  0f;}
        else{rb.gravityScale =  1f;}
        

    }
}





