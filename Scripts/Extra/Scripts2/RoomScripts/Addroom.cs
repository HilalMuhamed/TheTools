using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addroom : MonoBehaviour
{
    private RoomTemplete templete;
    void Start(){templete=GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplete>();
    templete.rooms.Add(this.gameObject);}
}
