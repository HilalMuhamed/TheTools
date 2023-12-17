using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroyer : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D hit)
        {
                if(hit.CompareTag("SpawnPoint")){Destroy(hit.gameObject);}
        }
}
