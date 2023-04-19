using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUPA : MonoBehaviour
{

    public float Ki;
    float maxKi = 100;

    PlayerMovement movement = new PlayerMovement();

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
        if (Input.GetKey(KeyCode.S) && Ki < maxKi)
        {
            anim.SetBool("KiCharge", true);
            kiSlider.value = Ki;
            Ki += 20 * Time.deltaTime;
            movement.movementSpeed = 0f;
            movement.jumpForce = 0f;
        }
        else if(Input.GetKeyUp(KeyCode.S) || Ki > maxKi)
        {
            anim.SetBool("KiCharge", false);
        }
    }



    private void setEnergy()
    {

    }

}
