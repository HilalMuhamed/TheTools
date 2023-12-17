using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject bulletDestructionParticle,sound1;
    public float speed = 5f;
    public float duration = 6f;

    private void Start()
    {
        Invoke("DestroyGameObject", duration); 
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void DestroyGameObject()
    {
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(bulletDestructionParticle,transform.position,Quaternion.identity);
        Destroy(gameObject); 
    }
}
