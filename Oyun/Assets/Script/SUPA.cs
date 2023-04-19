using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUPA : MonoBehaviour
{

    public float Ki;
    float maxKi = 100;

    public Slider kiSlider;

    public Animator anim;

    private void Start()
    {
        
    }

    private void Update()
    {
        KiCharge();
    }

    public void KiCharge()
    {
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("KiCharge", true);
            kiSlider.value = Ki;
            Ki += 14 * Time.deltaTime;
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("KiCharge", false);
        }
    }



    private void setEnergy()
    {

    }

}
