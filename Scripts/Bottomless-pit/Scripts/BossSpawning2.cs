using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawning2 : MonoBehaviour
{
    public GameObject enemy;
    
    // public Transform SpawnPoint;
    private float TimeBetweenSpawn;
    public float startTimeBetWeenSpawn;
    public float TimeDifference;
    public float TimeLimit;
    
    public float moveSpeed;
    public bool active = false;
    public GameObject SpawnTracker;

void Start()
{TimeBetweenSpawn = startTimeBetWeenSpawn;}
void Update()
{
    if(TimeBetweenSpawn <=0)
    {
        
        active = !active;
        if(active){
             SpawnTracker.GetComponent<SpawnerDeactivate>().SpawnDeactive();
             enemy.SetActive(active);enemy.transform.Translate((new Vector2(0,4.3f))*moveSpeed*Time.deltaTime);TimeBetweenSpawn = TimeDifference;}
        else{
            SpawnTracker.GetComponent<SpawnerDeactivate>().SpawnActive();
            enemy.transform.Translate((new Vector2(enemy.transform.position.x,30))*moveSpeed*moveSpeed*Time.deltaTime);enemy.SetActive(active);TimeBetweenSpawn = TimeLimit;}
    }
    else{TimeBetweenSpawn -=Time.deltaTime;}
}
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BossSpawning : MonoBehaviour
// {
//     private float TimeBetweenSpawn;
//     public float startTimeBetWeenSpawn;
//     public float moveSpeed;
//     public bool active = false;

// void Start()
// {TimeBetweenSpawn = startTimeBetWeenSpawn;}
// void Update()
// {
//     if(TimeBetweenSpawn <=0)
//     {
//         active = !active;
//         if(active){transform.Translate((new Vector2(0,-20))*moveSpeed*Time.deltaTime);}
//         else{transform.Translate((new Vector2(0,-40))*moveSpeed*Time.deltaTime);}
//         TimeBetweenSpawn = startTimeBetWeenSpawn;
//     }
//     else{TimeBetweenSpawn -=Time.deltaTime;}
// }
// }
