using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
   public Transform player;
   void Update()
   {
    Vector2 direction = player.position - transform.position;
    float angle =Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f,0f,angle);
   }
}
