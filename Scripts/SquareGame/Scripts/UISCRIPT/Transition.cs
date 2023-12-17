using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    public Animator transtionAnim;
    public string sceneName;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
           StartCoroutine(LoadScene());
        }
    }
    IEnumerator LoadScene(){
        transtionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
         SceneManager.LoadScene(sceneName);
    }
}
