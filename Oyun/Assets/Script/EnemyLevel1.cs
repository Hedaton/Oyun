using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel1 : MonoBehaviour
{

    public Vector2 pos1;
    public Vector2 pos2;
    public float speed = 1f;
    private float oldPosition;

    public float distance;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    

    void Update()
    {
        EnemyMove();
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
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
        }
    }


}
