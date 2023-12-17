using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
 public Color basecolor,offsetcolor;
 public SpriteRenderer renderer;
 

 public void Init(bool isOffset)
 {
    renderer.color = isOffset ? offsetcolor : basecolor; 
 }
 public Color returnColor(){return offsetcolor;}
}
