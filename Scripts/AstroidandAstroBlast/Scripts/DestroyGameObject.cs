using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float lifetime = 6;

    void Start()
    {
        Destroy(gameObject,lifetime);
    }

}
