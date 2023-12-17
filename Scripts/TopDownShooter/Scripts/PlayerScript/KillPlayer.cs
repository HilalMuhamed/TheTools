using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject deathParticle1;
    public GameObject deathParticle2;
    public GameObject sound1;
   void OnTriggerEnter2D(Collider2D hitinfo)
   {
    if(hitinfo.CompareTag("Enemy"))
    {
        gameObject.SetActive(false);
        Instantiate(deathParticle1,transform.position,Quaternion.identity);
        Instantiate(deathParticle2,transform.position,Quaternion.identity);
        Instantiate(sound1,transform.position,Quaternion.identity);
        Invoke("Death",2f);
    }
   }
   public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
