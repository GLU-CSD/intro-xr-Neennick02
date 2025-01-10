using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationAndScale : MonoBehaviour
{
    public Slider rotationSlider;
    public Slider scaleSlider;

    private float angleSliderNumber;
    private float scaleSliderNumber;

    private float minimunScaleValue = 0.05f;
    private void Start()
    {
        angleSliderNumber = 10f;
    }
    void Update()
    {
        if(scaleSlider.value < minimunScaleValue)
        {
            scaleSlider.value = minimunScaleValue;
        }


        angleSliderNumber = rotationSlider.value * 360f;
        this.transform.rotation = Quaternion.Euler(0, angleSliderNumber, 0);

        scaleSliderNumber = scaleSlider.value * 2f;
        Vector3 scale = new Vector3(scaleSliderNumber, scaleSliderNumber, scaleSliderNumber);
        this.transform.localScale = scale;
        Debug.Log(scaleSliderNumber);
    }
}
