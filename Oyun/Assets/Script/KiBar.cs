using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KiBar : MonoBehaviour
{
    SUPA supa;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        supa = GetComponent<SUPA>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (supa.kiFull==true)
        {
            animator.SetTrigger("KiBarStart");
            animator.SetBool("KiFull", true);
        }
        else
        {
            animator.SetBool("KiFull", false);
        }
    }
}
