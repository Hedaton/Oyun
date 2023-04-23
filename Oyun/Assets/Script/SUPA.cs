using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUPA : MonoBehaviour
{

    public float Ki = 0.01f;
    float maxKi = 100;
    float timer = 0f;
    float kamehaTimer = 0f;
    float waitTime = 0.3f;
    int sCount = 0;

    public float increaseRate = 2.3f;
    public float healt = 100;


    public bool ssj = true;
    public bool ssgss = false;
    public bool kame = false;
    public bool dead = false;
    public bool kamehameha = false;
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
            Kamehameha();
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
        if (Input.GetKeyDown(KeyCode.S) && Ki < maxKi && movement.isGrounded == true)
        {
            Lock();
            charcing = true;
            anim.SetTrigger("Ki");
        }
        else if (Input.GetKey(KeyCode.S) && Ki < maxKi)
        {
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

    public void Kamehameha()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Ki > 50f)
        {
            Lock();
            Ki -= 50;
            kamehameha = true;
            anim.SetTrigger("Kamehameha");
        }
        if (Input.GetKey(KeyCode.Q) && Ki >= 3f)
        {
            kamehaTimer += Time.deltaTime;

            if (kamehaTimer >= waitTime)
            {
                anim.speed = 1f;
                anim.SetBool("isKamehameha", true);
                Ki -= 3f;
                kiSlider.value = Ki;
                kamehaTimer = 0f; // Sayaç sýfýrlanýyor.
            }

        }
        else
        {
            anim.SetBool("isKamehameha", false);
            Unlock();
            kamehaTimer = 0f; // Eðer Q tuþu basýlý deðilse sayaç sýfýrlanýyor.
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
            if (sCount == 3 && movement.isGrounded == true)
            {
                StartCoroutine(RunCodeForSomeTime(2f));
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
        float timeInterval = sec;
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
