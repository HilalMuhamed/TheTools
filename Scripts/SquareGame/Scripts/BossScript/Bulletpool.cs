using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletpool : MonoBehaviour
{
    public static Bulletpool bulletPoolInstanse;
    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;

    private void Awake(){bulletPoolInstanse = this;}
    void Start()
    {
        bullets = new List<GameObject>();        
    }
    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i=0;i<bullets.Count;i++)
            {
                if(!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
    
    if(notEnoughBulletsInPool){
        GameObject bul = Instantiate(pooledBullet);
        bul.SetActive(false);
        bullets.Add(bul);
        return bul;
    }
    return null;
    }
}