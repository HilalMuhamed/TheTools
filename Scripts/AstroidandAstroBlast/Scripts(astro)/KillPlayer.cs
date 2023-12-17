using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject deathparticle1,deathparticle2,sound1;
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("Enemy") || hit.gameObject.CompareTag("Astroid"))
        {
            Instantiate(sound1,transform.position,Quaternion.identity);
            Instantiate(deathparticle1,transform.position,Quaternion.identity);
            Instantiate(deathparticle2,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
            Invoke("NextLevel",1.2f);
        }
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
