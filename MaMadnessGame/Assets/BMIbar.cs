using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BMIbar : MonoBehaviour
{
    public Slider slider;
    public Gradient BMILevel;
    public Image fill;

    public void SetMaxBMI(float BMI) {
        slider.maxValue = BMI;
        slider.value = BMI;

        fill.color = BMILevel.Evaluate(1f);
    }

    public void SetBMI(float BMI) {
        slider.value = BMI;

        fill.color = BMILevel.Evaluate(slider.normalizedValue);
    }
}
