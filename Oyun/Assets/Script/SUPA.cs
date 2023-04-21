using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUPA : MonoBehaviour
{

    public float Ki = 0.01f;
    float maxKi = 100;

    public float increaseRate = 2.3f;
    public float healt = 100;
    public bool kame = false;
    public bool dead = false;
    public bool charcing;
    public bool kiFull;

    PlayerMovement movement;

    public Slider kiSlider;
    public Slider healtSlider;

    Animator anim;
    public Animator animator;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        KiFull();
        if (dead == false)
        {
            KiCharge();
            setHealt();
        }

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
            healt = 0;
            Lock();
            anim.SetTrigger("isDeath");
            anim.SetBool("Death", true);
            dead = true;

        }
    }

    public void KiCharge()
    {
        if (Input.GetKeyDown(KeyCode.S) && Ki < maxKi)
        {
            charcing = true;
            anim.SetTrigger("Ki");
        }
        else if (Input.GetKey(KeyCode.S) && Ki < maxKi)
        {
            Lock();
            anim.speed = 1f;
            anim.SetBool("KiCharge", true);
            if (Ki * (1.0f + increaseRate * Time.deltaTime) > maxKi)
            {
                Ki = 100f;
                animator.SetTrigger("initialKiFull");
            }
            else
            {
                kiSlider.value = Ki;
                Ki *= (1.0f + increaseRate * Time.deltaTime);
            }

        }
        else if (Input.GetKeyUp(KeyCode.S) || Ki > maxKi)
        {
            charcing = false;
            anim.SetBool("KiCharge", false);
            Unlock();
        }
    }

    void Lock()
    {
        movement.movementSpeed = 0f;
        movement.jumpForce = 0f;
    }

    void Unlock()
    {
        movement.movementSpeed = movement.initialMovementSpeed;
        movement.jumpForce = movement.initialJumpForce;
    }

    void KiFull()
    {
        if (Ki == 100f)
        {
            kiFull = true;
            animator.SetBool("KiFull", true);
        }
        else
        {
            kiFull = false;
            animator.SetBool("KiFull", false);
        }
    }

    private void setEnergy()
    {

    }

}
