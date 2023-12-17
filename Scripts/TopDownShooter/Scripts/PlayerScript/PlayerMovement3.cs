using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3 : MonoBehaviour
{

    
    public float speed;
    public GameObject deathParticle1,deathParticle2;
    public GameObject sound1;
    void FixedUpdate()
    {
        
        transform.position = (Vector2)transform.position + new Vector2(Input.GetAxis("Horizontal")*speed*Time.deltaTime,Input.GetAxis("Vertical")*speed*Time.deltaTime);
        if( transform.position.y < -10  || transform.position.y > 10 )
        {
            Instantiate(deathParticle1,transform.position,Quaternion.identity);
            Instantiate(deathParticle2,transform.position,Quaternion.identity);
            Instantiate(sound1,transform.position,Quaternion.identity);
            transform.position =    new Vector2( (transform.position.x),-(transform.position.y));
            Instantiate(deathParticle1,transform.position,Quaternion.identity);
            Instantiate(deathParticle2,transform.position,Quaternion.identity);
        }
        if(transform.position.x < -19.5 ||transform.position.x > 19.5 )
        {
            Instantiate(deathParticle1,transform.position,Quaternion.identity);
            Instantiate(deathParticle2,transform.position,Quaternion.identity);
            Instantiate(sound1,transform.position,Quaternion.identity);
            transform.position =    new Vector2( -(transform.position.x),(transform.position.y));
            Instantiate(deathParticle1,transform.position,Quaternion.identity);
            Instantiate(deathParticle2,transform.position,Quaternion.identity);
        }
    // public GameObject targetObject;
    // public float frequencyIncrease =100f;
    // public float orginalDuration =0.5f;
    // public float duration = 0.5f;
    // private ParticleSystem targetParticleSystem;
    // private ParticleSystem.NoiseModule noiseModule;
    // private float originalFrequency;
    //
    //void Start()
    //{
    //      targetParticleSystem = targetObject.GetComponent<ParticleSystem>();
    //     noiseModule = targetParticleSystem.noise;
    //     originalFrequency = noiseModule.frequency;
     //}

    //     if(Input.anyKey)
    //     {if (duration > 0)
    //     {
    //         noiseModule.frequency += frequencyIncrease * Time.deltaTime;
    //         duration -= Time.deltaTime;
    //     }
    //     else
    //     {
    //         noiseModule.frequency = originalFrequency;
    //         duration = orginalDuration;
    //     }
    // }
}
}

