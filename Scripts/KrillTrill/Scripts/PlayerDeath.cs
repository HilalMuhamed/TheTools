using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathEffect1,sound1;
    void OnCollisionEnter2D(Collision2D hit)
    {
        Instantiate(sound1, transform.position, Quaternion.identity);
        Instantiate(deathEffect1, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Invoke("Destroyplayer",2f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(sound1, transform.position, Quaternion.identity);
        Instantiate(deathEffect1, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Invoke("Destroyplayer",2f);
    }
    void Destroyplayer(){SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);}
}
