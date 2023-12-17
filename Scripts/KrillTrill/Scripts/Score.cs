using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    
   public int playerScore=0;
   public TMP_Text mytext;
   void Start()
   {
      PlayerPrefs.SetString("TextData","0");
      InvokeRepeating("addScore",0f,1f);
   }
   public void addScore()
   {
    playerScore =playerScore+1;
    mytext.text = "Distance: "+playerScore.ToString();
    PlayerPrefs.SetString("TextData",playerScore.ToString());
   }
}
