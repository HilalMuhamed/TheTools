using System.Collections;
using UnityEngine;

public class ParticleActivatoinScript : MonoBehaviour
{
    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;
    private bool isObjectActive = true;
    private float intialDelay = 58f;
    private float timer = 60f;

    private void Start()
    {
        Invoke("ActivateDeactivateObjects", intialDelay);
        InvokeRepeating("ActivateDeactivateObjects", intialDelay + timer, timer);
    }

    private void ActivateDeactivateObjects()
    {
    
        particle1.SetActive(!isObjectActive);
        particle2.SetActive(!isObjectActive);
        particle3.SetActive(isObjectActive);
        particle4.SetActive(isObjectActive);
        isObjectActive = !isObjectActive;
    }
}







