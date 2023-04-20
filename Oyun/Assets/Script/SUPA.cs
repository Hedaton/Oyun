using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUPA : MonoBehaviour
{

    public float Ki;
    float maxKi = 100;

    public float healt = 100;
    public bool kame = false;
    bool dead = false;

    PlayerMovement movement;

    public Slider kiSlider;
    public Slider healtSlider;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        KiCharge();
        setHealt();
        Dead();
    }

    public void setHealt()
    {
        if (kame)
        {
            healt -= 10 * Time.deltaTime;
            healtSlider.value = healt;
        }

        if (healt <= 0)
        {
            dead = true;
            healt = 0;
            
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

    public void Dead()
    {
        if (dead)
        {
            print("�ld�m");
            anim.SetBool("Death", true);
           
        }
    }

    private void setEnergy()
    {

    }

}
