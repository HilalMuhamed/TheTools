using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionGrow : MonoBehaviour
{
    public Vector3 targetSize;
    public float duration = 1f;

    private Vector3 initialSize;
    private float elapsedTime = 0f;
    public bool isGrowing = true;
    public float timeInterval = 15f;

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public GameObject Gun;

    private void Start()
    {
        // Get the initial size of the GameObject
        initialSize = transform.localScale;

        // Start the size changing coroutine
        StartCoroutine(CallCoroutineRepeatedly());
    }
    
    private System.Collections.IEnumerator CallCoroutineRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            StartCoroutine(ChangeSize());
            Gun.SetActive(!isGrowing);
            // SwitchAudioSource();
        }
    }

    private System.Collections.IEnumerator ChangeSize()
    {
        while (elapsedTime < duration)
        {
            // Calculate the new size based on the current time elapsed
            Vector3 newSize = isGrowing ? Vector3.Lerp(initialSize, targetSize, elapsedTime / duration) : Vector3.Lerp(targetSize, initialSize, elapsedTime / duration);


            // Set the new size of the GameObject
            transform.localScale = newSize;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the final size is set correctly
        transform.localScale = isGrowing ? targetSize : initialSize;

        // Reverse the animation
        isGrowing = !isGrowing;
        elapsedTime = 0f;
    }
    private void SwitchAudioSource()
    {
        audioSource1.enabled = isGrowing;
        audioSource2.enabled = !isGrowing;
    }
}
