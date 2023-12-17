using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnSpot;
    private float TimeBetweenSpawn;
    public float startTimeBetWeenSpawn;
    public float TimeDecrease;
    public float TimeDifference;
    public float minTime;

void Start()
{TimeBetweenSpawn = startTimeBetWeenSpawn;}
void Update()
{
    if(TimeBetweenSpawn <=0)
    {
        int randpos = Random.Range(0,spawnSpot.Length-1);
        Instantiate(enemy,spawnSpot[randpos].position,Quaternion.identity);
        TimeBetweenSpawn = TimeDifference;
    }
    else{TimeBetweenSpawn -=Time.deltaTime;}
    if(TimeDifference > minTime){TimeDifference = TimeDifference- TimeDecrease * Time.deltaTime;}
}
}
