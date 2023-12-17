using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STARTLEVEL : MonoBehaviour
{
    public void Easy(){SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);}
    public void Hard(){SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 2);}
    public void Crazy(){SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 3);}

    public void QuitBtn(){Application.Quit();}

    
}
