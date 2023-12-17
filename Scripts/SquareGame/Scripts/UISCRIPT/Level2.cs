using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    
    public void Select1 (string levelName){
        SceneManager.LoadScene(3);

        if (String.Equals(levelName, "1")){SceneManager.LoadScene(1);}
        else if (String.Equals(levelName, "2")){SceneManager.LoadScene(3);}
        else if (String.Equals(levelName, "3")){SceneManager.LoadScene(5);}
        else if (String.Equals(levelName, "4")){SceneManager.LoadScene(7);}
        else if (String.Equals(levelName, "5")){SceneManager.LoadScene(9);}
        else if (String.Equals(levelName, "6")){SceneManager.LoadScene(11);}
        
    }
}
