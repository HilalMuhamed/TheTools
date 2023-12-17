using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class post : MonoBehaviour
{
    public int intensityValue1 = 1;
    public int intensityValue2 = 5;
    public int toggleDuration = 30;
    private Bloom bloom;
    private void Start()
    {
        PostProcessVolume postProcessVolume = GetComponent<PostProcessVolume>();
        if (postProcessVolume != null && postProcessVolume.profile.TryGetSettings(out bloom))
        {
            StartCoroutine(ToggleBloomIntensity());
        }
    }
    
    private IEnumerator ToggleBloomIntensity()
    {
        while (true)
        {
            bloom.intensity.value = intensityValue1;
            yield return new WaitForSeconds(toggleDuration);
            bloom.intensity.value = intensityValue2;
            yield return new WaitForSeconds(toggleDuration);
        }
    }
}
