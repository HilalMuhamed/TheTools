using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletPool2 : MonoBehaviour
{
    public static BulletPool2 bulletPoolInstanse;
    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;
    private List<GameObject> bullets2;
    private void Awake(){bulletPoolInstanse = this;}
    void Start()
    {
        bullets2 = new List<GameObject>();        
    }
    public GameObject GetBullet()
    {
        if(bullets2.Count > 0)
        {
            for(int i=0;i<bullets2.Count;i++)
            {
                if(!bullets2[i].activeInHierarchy)
                {
                    return bullets2[i];
                }
            }
        }
    
    if(notEnoughBulletsInPool){
        GameObject bul = Instantiate(pooledBullet);
        bul.SetActive(false);
        bullets2.Add(bul);
        return bul;
    }
    return null;
    }
}