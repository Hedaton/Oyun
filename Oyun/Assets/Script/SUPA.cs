using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUPA : MonoBehaviour
{

    public float Ki;
    float maxKi = 100;

    public float healt;
    float maxHealt = 100;
    public bool kame = false;

    PlayerMovement movement;

    public Slider kiSlider;
    public Slider healtSlider;

    public Animator anim;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        KiCharge();
        getHealt();
    }

    public void getHealt()
    {
        if (kame)
        {
            healt -= 10;
        }
    }

    public void KiCharge()
    {
        if (Input.GetKey(KeyCode.S) && Ki <maxKi)
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
            movement.movementSpeed = movement.initialMovementSpeed;
            movement.jumpForce = 45f;
        }
    }



    private void setEnergy()
    {

    }

}
