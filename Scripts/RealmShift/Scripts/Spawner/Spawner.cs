using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnSpot;
    private float TimeBetweenSpawn;
    public float startTimeBetWeenSpawn;
    // public float TimeDecrease;
    // public float minTime;
    public GameObject deathParticle1;
    public DimentionGrow d;

void Start()
{TimeBetweenSpawn = startTimeBetWeenSpawn;}
void Update()
{
    if(TimeBetweenSpawn <=0 && d.isGrowing)
    {
        int randpos = Random.Range(0,spawnSpot.Length-1);
        Instantiate(deathParticle1,spawnSpot[randpos].position,Quaternion.identity);
        Instantiate(enemy,spawnSpot[randpos].position,Quaternion.identity);
        TimeBetweenSpawn = startTimeBetWeenSpawn;
    }
    else{TimeBetweenSpawn -=Time.deltaTime;}
    // if(startTimeBetWeenSpawn > minTime){startTimeBetWeenSpawn = startTimeBetWeenSpawn- TimeDecrease * Time.deltaTime;}
}
}