using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUPA : MonoBehaviour
{

    public float Ki;
    float maxKi = 100;

    public Slider kiSlider;

    private void Update()
    {
        kiSlider.value = Ki;
    }

    private void setEnergy()
    {

    }

}
