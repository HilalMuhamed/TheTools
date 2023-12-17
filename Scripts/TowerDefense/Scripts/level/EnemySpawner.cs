using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemySpawner : MonoBehaviour
{
    [Header("Reference")]
    public GameObject[] enemies;
    [Header("Attributes")]
    public int baseEnemies = 8;
    public float enemiespersecond = 1f;
    public int currentwave = 1;
    public float timeBtwWaves =5f;
    private float timeSiceLastSpawn;
    public int enemiesalive = 0;
    private int enemiesleftToSpawn;
    public float difcultyscalingfactor = 0.75f;
    private bool isSpawning = false;
    private float eps;//Enmies per second
    public float enemiespersecondcap = 10;
    public float maxWave = 10f;
    public GameObject EndScreen;
    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();
    void Awake(){onEnemyDestroy.AddListener(EnemyDestroyed);}
    void Start(){StartCoroutine(StartWave());eps=enemiespersecond;}
    void Update(){
        if(currentwave==maxWave){EndScreen.SetActive(true);return;}
        if(!isSpawning){return;}
        timeSiceLastSpawn += Time.deltaTime;
        if(timeSiceLastSpawn >= (1f/eps) && enemiesleftToSpawn > 0f && currentwave <= maxWave)
        {SpawnEnemy();
        enemiesleftToSpawn--; 
        enemiesalive++; 
        timeSiceLastSpawn=0f;}
        if(enemiesalive==0&&enemiesleftToSpawn==0){EndWave();}
    }
    private void EndWave(){currentwave++; isSpawning=false;timeSiceLastSpawn=0f;StartCoroutine(StartWave());}
    private void EnemyDestroyed(){enemiesalive--;}
    void SpawnEnemy()
    {
        int index = Random.Range(0,enemies.Length);
        Instantiate(enemies[index],levelManger.main.startingpath.position,Quaternion.identity);}
    IEnumerator StartWave(){
        yield return new WaitForSeconds(timeBtwWaves);
        isSpawning = true; enemiesleftToSpawn = EnemiesPerWave();
        eps=EnemiesPerSecond();}
    int EnemiesPerWave(){return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentwave,difcultyscalingfactor));}
    float EnemiesPerSecond(){return Mathf.Clamp(enemiespersecond * Mathf.Pow(currentwave,difcultyscalingfactor),0,enemiespersecondcap);}

}
