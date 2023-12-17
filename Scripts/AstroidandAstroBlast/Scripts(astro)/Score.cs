using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    
   public int playerScore=0;
   public Text mytext;
   void Start()
   {
      PlayerPrefs.SetString("TextData","0");
   }
   public void addScore(int i)
   {
    playerScore =playerScore+i;
    mytext.text = "Score : "+playerScore.ToString();
    PlayerPrefs.SetString("TextData",playerScore.ToString());
   }
}
