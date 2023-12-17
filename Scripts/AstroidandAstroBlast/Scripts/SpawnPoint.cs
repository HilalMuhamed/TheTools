using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] obstacle;
    void Start()
    {
        int rand  = Random.Range(0,obstacle.Length);
        Instantiate(obstacle[rand],transform.position,Quaternion.identity);
    }

}
