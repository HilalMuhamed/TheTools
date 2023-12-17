using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangin : MonoBehaviour
{
    public MonoBehaviour scriptA;
    public MonoBehaviour scriptB;
    public Animator animator;
    public RuntimeAnimatorController controller1;
    public RuntimeAnimatorController controller2;
    public GameObject particles;

    public float switchInterval = 15f;
    private float elapsedTime = 0f;
    private bool isSwitched = false;

        private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= switchInterval)
        {
            elapsedTime = 0f;
            isSwitched = !isSwitched;

            if (isSwitched)
            {
                scriptA.enabled = true;
                scriptB.enabled = false;
                animator.runtimeAnimatorController = controller1;
                Instantiate(particles,transform.position,Quaternion.identity);
            }
            else
            {
                scriptA.enabled = false;
                scriptB.enabled = true;
                 animator.runtimeAnimatorController = controller2;
                 Instantiate(particles,transform.position,Quaternion.identity);
            }
        }
    }

}
