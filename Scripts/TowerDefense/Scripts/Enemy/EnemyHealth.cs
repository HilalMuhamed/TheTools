using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Attributes")]
    public float hitPoints = 2;
    private bool isDeastroyed = false;
    public int CurrencyWorth = 50;
    public GameObject deathParticle;
    public void TakeDamage(float damage)
    {
        
        hitPoints -=damage;
        if(hitPoints<=0 && !isDeastroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            levelManger.main.IncreaseCurrency(CurrencyWorth);
            isDeastroyed=true;
            Instantiate(deathParticle,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
