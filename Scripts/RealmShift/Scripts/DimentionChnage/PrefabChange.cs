using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PrefabChange : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject particles;
    private int currentIndex = 0;

    public float changeInterval = 10f;
    private float timer = 0f;

    private void Start()
    {
        InstantiatePrefab();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            timer = 0f;
            ChangePrefab();
        }
    }

    private void ChangePrefab()
    {
        currentIndex = (currentIndex + 1) % prefabs.Length;
        InstantiatePrefab();
        Destroy(gameObject);
    }

    private void InstantiatePrefab()
    {
        Instantiate(particles, transform.position,Quaternion.identity);
        Instantiate(prefabs[currentIndex], transform.position, transform.rotation);
    }
}
