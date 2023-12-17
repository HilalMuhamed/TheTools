using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 - Down room |  2 - top room | 3 - left room | 4 - right room
    private RoomTemplete templete;
    private int rand;
    private bool spawned = false;
    public float waitTime = 4f;
    void Start()
    {
        Destroy(gameObject,waitTime);
        templete = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplete>();
        Invoke("Spawn",0.3f);
    }
    void Spawn()
    {
        if(spawned == false)
        {
        if(openingDirection == 2 )
        {
            rand = Random.Range(0,templete.DownRooms.Length);
            Instantiate(templete.DownRooms[rand],transform.position,Quaternion.identity);
        }
        else if(openingDirection ==1)
        {
            rand = Random.Range(0,templete.TopRooms.Length);
            Instantiate(templete.TopRooms[rand],transform.position,Quaternion.identity);
        }
        else if(openingDirection == 4)
        {
            rand = Random.Range(0,templete.LeftRooms.Length);
            Instantiate(templete.LeftRooms[rand],transform.position,Quaternion.identity);
        }
        else if(openingDirection == 3)
        {
            rand = Random.Range(0,templete.RightRooms.Length);
            Instantiate(templete.RightRooms[rand],transform.position,Quaternion.identity);
        }
        spawned = true;
        }

    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.CompareTag("SpawnPoint"))
        {
            if( hit.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templete.closedRoom,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
