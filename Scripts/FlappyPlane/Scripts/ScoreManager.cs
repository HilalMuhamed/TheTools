using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject GameOverScreen;
    
    public void addScore()
    {
        playerScore = playerScore +1;
        scoreText.text = playerScore.ToString();
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void gameOver()
    {
        GameOverScreen.SetActive(true);
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }
}
