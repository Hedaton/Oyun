using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class EnemyLevel1 : MonoBehaviour
{

    [SerializeField] SUPA supa;
    public Vector2 pos1;
    public Vector2 pos2;
    public float speed = 1f;
    private float oldPosition;

    public float distance;

    private Transform target;
    public float followSpeed;

    private Animator anim;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();

    }

    

    void Update()
    {
        EnemyAi();  
    }

    void EnemyMove()
    {
        
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        Thread.Sleep(1000);

        transform.localRotation = Quaternion.Euler(0, 0, 0);
        
        
    }

    void EnemyAi()
    {
        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, -transform.right, distance);

        if (hitEnemy.collider !=null)
        {
            supa.kame = true;
            Debug.DrawLine(transform.position, hitEnemy.point, Color.red);
            print("saldýr");
            EnemyFollow();
            anim.SetBool("EnemyAttack", true);
        }
        else
        {
            supa.kame = false;
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            print("saldýrma");
            EnemyMove();
            anim.SetBool("EnemyAttack", false);
        }
    }

    void EnemyFollow()
    {
        Vector3 targetPosition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

}
