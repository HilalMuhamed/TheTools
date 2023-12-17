using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeactivate : MonoBehaviour
{
    // public GameObject[] spawners;
    public GameObject spawners;
    public void SpawnActive(){
        // for(int i=0;i<spawners.Length-1;i++){spawners[i].SetActive(true);}
        spawners.SetActive(true);
        }
    
    public void SpawnDeactive()
    {
        // for(int i=0;i<spawners.Length-1;i++){spawners[i].SetActive(false);}
        spawners.SetActive(false);
    }
}
