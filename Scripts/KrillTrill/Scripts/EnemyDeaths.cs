using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeaths : MonoBehaviour
{
    public float time = 5f;
    void Start(){Destroy(gameObject,time);}
}