using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public Astroid astroidprefab;
    public float spawnRate = 2f;
    public int spawnAmt =1;
    public float spawnDistance =32f;
    public float TheVaraiance = 20f;
    void Start()
    {
        InvokeRepeating("Spawn",spawnRate,spawnRate);
    }
    void Spawn()
    {
        for(int i=0;i<spawnAmt;i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized *spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;
            float variance = Random.Range(-TheVaraiance,TheVaraiance);
            Quaternion rot = Quaternion.AngleAxis(variance, Vector3.forward);
            Astroid astroid = Instantiate(astroidprefab,spawnPoint,rot);
            astroid.size = Random.Range(astroid.minSize,astroid.maxSize);
            astroid.Trajectory(rot *-spawnDirection);
        } 
    }


 
}
