using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;

    void Update()
    {
        scoreDisplay.text = "SCORE: " +score.ToString();
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("New"))
        {
            score++;
            
        }
    }
}
