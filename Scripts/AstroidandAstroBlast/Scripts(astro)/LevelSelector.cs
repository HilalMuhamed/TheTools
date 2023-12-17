using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector: MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
        Time.timeScale=1f;
    }
    public void CreditBtn()
    {
        SceneManager.LoadScene(3);
    }
}
