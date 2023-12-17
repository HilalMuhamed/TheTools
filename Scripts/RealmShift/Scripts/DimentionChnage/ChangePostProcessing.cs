using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangePostProcessing : MonoBehaviour
{
    public PostProcessProfile[] profiles;  // Array of post-processing profiles
    public float interval = 15f;  // Time interval to switch profiles (in seconds)

    private PostProcessVolume postProcessVolume;
    private int currentProfileIndex = 0;
    private float timer = 0f;

    public TimerScript t;

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        t.SetMaxTimer(interval);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        t.SetTimer(timer);

        if (timer >= interval)
        {
            timer = 0f;

            // Switch to the next profile
            currentProfileIndex = (currentProfileIndex + 1) % profiles.Length;
            postProcessVolume.profile = profiles[currentProfileIndex];
        }
    }
}