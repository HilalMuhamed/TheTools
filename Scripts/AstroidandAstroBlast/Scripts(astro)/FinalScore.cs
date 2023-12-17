using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FinalScore : MonoBehaviour
{
    
   public Text mytext;
   
   void Start()
   {

    string textData = PlayerPrefs.GetString("TextData");
    mytext.text = "Score : " +textData;
   }
}