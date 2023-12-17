using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    public GameObject targetObject;
    public ParticleSystem SourceParticleSystem;
    private ParticleSystem targetParticleSystem;
    void Start()
    {
        targetParticleSystem = targetObject.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule mainModule1 = SourceParticleSystem.main;
        ParticleSystem.MainModule mainModule2 = targetParticleSystem.main;
        mainModule1.startColor = mainModule2.startColor;
    }

    void Update()
    {
        ParticleSystem.MainModule mainModule1 = SourceParticleSystem.main;
        ParticleSystem.MainModule mainModule2 = targetParticleSystem.main;
        mainModule2.startColor = mainModule1.startColor;
    }
}
