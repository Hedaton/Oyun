using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class EnemyLevel1 : MonoBehaviour
{

    [SerializeField] SUPA supa;
    public float speed = 1f;

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

            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            
            //transform.localRotation = Quaternion.Euler(0, 0, 0);

        
    }

    void EnemyAi()
    {
        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hitEnemy.collider !=null)
        {
            supa.kame = true;
            Debug.DrawLine(transform.position, hitEnemy.point, Color.red);
            //EnemyFollow();
        }
        else
        {
            supa.kame = false;
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            
            EnemyMove();
        }
    }

    void EnemyFollow()
    {
        Vector3 targetPosition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

}
