using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplete : MonoBehaviour
{
    public GameObject[] TopRooms;
    public GameObject[] DownRooms;
    public GameObject[] RightRooms;
    public GameObject[] LeftRooms;

    public GameObject closedRoom;
    public List<GameObject> rooms;
    public float waitTime;
    public bool spawnBoss;
    public GameObject Boss;
    
    void Update()
    {
        if(waitTime <= 0 && spawnBoss == false)
        {
            Instantiate(Boss, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            spawnBoss = true;
        }
        else if (waitTime >= 0 )
        {
            waitTime -=Time.deltaTime;
        }
    }
}
