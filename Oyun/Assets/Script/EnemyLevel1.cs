using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel1 : MonoBehaviour
{

    public SUPA supa;
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
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

        if (transform.position.x > oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (transform.position.x < oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        oldPosition = transform.position.x;
    }

    void EnemyAi()
    {
        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, -transform.right, distance);

        if (hitEnemy.collider !=null)
        {
            Debug.DrawLine(transform.position, hitEnemy.point, Color.red);
            anim.SetBool("EnemyAttack", true);
            print("saldýr");
            EnemyFollow();
            supa.kame = true;
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            print("saldýrma");
            anim.SetBool("EnemyAttack", false);
            EnemyMove();
            supa.kame = false;
        }
    }

    void EnemyFollow()
    {
        Vector3 targetPosition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

}
