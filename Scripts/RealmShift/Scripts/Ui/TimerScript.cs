using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxTimer (float timer)
    {
        slider.maxValue = timer;
        slider.value = timer;
        fill.color = gradient.Evaluate(1f);
    }

    public void  SetTimer(float timer)
    {
        slider.value = timer;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
