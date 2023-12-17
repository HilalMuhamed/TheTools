using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;
    private float Timer =0;
    public float hightOffset;
    private float count =0;
    public float timeInrease;
    public float maxTime;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if(Timer < spawnRate)
        {
            Timer += Time.deltaTime;
        }
        else{
            SpawnPipe();
            if(count < maxTime)
            {
                count = count + timeInrease;
            }
            Timer =0 + count;
            }
    }
    
    void SpawnPipe()
    {
        float lowpoint = transform.position.y - hightOffset;
        float highpoint = transform.position.y + hightOffset;
        Instantiate(pipe,new Vector3(transform.position.x,Random.Range(lowpoint,highpoint),transform.position.z),Quaternion.identity);
    }
}
