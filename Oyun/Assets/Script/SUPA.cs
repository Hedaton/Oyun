using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUPA : MonoBehaviour
{

    public float Ki = 0.01f;
    float maxKi = 100;
    float timer = 0f;
    int sCount = 0;

    public float increaseRate = 2.3f;
    public float healt = 100;

    public bool ssj = true;
    public bool ssgss = false;
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

        anim.SetBool("SSJ", ssj);
        anim.SetBool("SSGSS", ssgss);
    }

    private void Update()
    {
        KiFull();
        if (dead == false)
        {
            Transform();
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
        charcing = true;
    }

    void Unlock()
    {
        charcing = false;
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

    void Transform()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sCount++;
        }

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            if (sCount == 3)
            {
                StartCoroutine(RunCodeForSomeTime(2.5f));
                ssj = !ssj;
                ssgss = !ssgss;
                anim.SetTrigger("Transform");
                anim.SetBool("SSJ", ssj);
                anim.SetBool("SSGSS", ssgss);
               

            }
            // sCount ve timer'ý sýfýrla
            sCount = 0;
            timer = 0f;
        }
    }

    IEnumerator RunCodeForSomeTime(float sec)
    {
        float totalTime = sec;
        float timeInterval = 2.5f;
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            Lock();

            yield return new WaitForSeconds(timeInterval);

            elapsedTime += timeInterval;
        }

        Unlock();
    }

    private void setEnergy()
    {

    }

}
