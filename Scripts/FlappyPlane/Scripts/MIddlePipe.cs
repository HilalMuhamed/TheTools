using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIddlePipe : MonoBehaviour
{
    public ScoreManager s;
    void Start()
    {
        s = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }
   void OnTriggerEnter2D(Collider2D other)
   {
    if(other.CompareTag("Player")){
    s.addScore();
   }
   }
}
