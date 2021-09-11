using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image fill;
    public Gradient gradient;
    public Slider slider;
    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health){
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
