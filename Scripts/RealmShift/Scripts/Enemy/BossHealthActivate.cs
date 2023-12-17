using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthActivate : MonoBehaviour
{
    public GameObject BossHealth;
    public GameObject BossEntry;

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            BossHealth.SetActive(true);
            BossEntry.SetActive(true);
        }
    }
}
