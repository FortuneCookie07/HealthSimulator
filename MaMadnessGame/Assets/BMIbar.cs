using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BMIbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxBMI(float BMI) {
        slider.maxValue = BMI;
        slider.value = BMI;
    }

    public void SetBMI(float BMI) {
        slider.value = BMI;
    }
}
