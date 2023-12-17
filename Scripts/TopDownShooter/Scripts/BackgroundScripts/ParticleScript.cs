using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{


    public GameObject targetObject;
    public float frequencyIncrease = 10f;
    private ParticleSystem targetParticleSystem;
    private ParticleSystem.NoiseModule noiseModule;
    private float originalStrength;

    // Color change overtime 

    public Color[] StartColor ;
    public Color[] EndColor ;
    private Color startColor;
    private Color endColor;
    private int index;
    private float timer;
    public float timeBetween;

    void Start()
    {
        targetParticleSystem = targetObject.GetComponent<ParticleSystem>();
        noiseModule = targetParticleSystem.noise;
        originalStrength = noiseModule.strength.Evaluate(0);
        ChangeColor();

    }

    void Update()
    {
        if (Input.anyKey)
        {
            noiseModule.frequency = 0.5f;
            noiseModule.strength = originalStrength + frequencyIncrease * Time.deltaTime;
        }
        else
        {
            noiseModule.strength = originalStrength;
            noiseModule.frequency =0.5f; 
        }
        
        timer +=Time.deltaTime;
        if(timer>timeBetween)
        {
            ChangeColor();
            timer =0;
        }
    }
    void ChangeColor()
    {
        
        index =Random.Range(0,StartColor.Length);
        startColor =StartColor[index];
        endColor = EndColor[index];
        ParticleSystem.MainModule mainModule = targetParticleSystem.main;
        Color startColorWithAlpha = new Color(startColor.r, startColor.g, startColor.b, mainModule.startColor.color.a);
        Color endColorWithAlpha = new Color(endColor.r, endColor.g, endColor.b, mainModule.startColor.color.a);
        mainModule.startColor = new ParticleSystem.MinMaxGradient(startColorWithAlpha, endColorWithAlpha);
    }
}


