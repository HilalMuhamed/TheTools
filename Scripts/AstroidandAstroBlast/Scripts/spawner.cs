using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    
    public GameObject[] obstaclePatterns;
    public float startTimeBtwSpawn;
    private float TimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 1f;
    

    void Update()
    {
        if(TimeBtwSpawn <=0)
        {
            int rand  = Random.Range(0,obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand],transform.position,Quaternion.identity);
            TimeBtwSpawn = startTimeBtwSpawn;
            if(startTimeBtwSpawn > minTime){ startTimeBtwSpawn -= decreaseTime;}
        }
        else
        {
        TimeBtwSpawn -= Time.deltaTime;
        }
    }
}
