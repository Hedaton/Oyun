using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamehameha : MonoBehaviour
{

    [SerializeField] SUPA supa;
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    public float gunmenzil = 10f;
    

    private void Update()
    {
        kamehameha();    
    }

    void kamehameha()
    {
        Vector2 direction = mousePosition - (Vector2)transform.position;
        Vector2 endPoint = mousePosition;

        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, transform.right, gunmenzil);
        if (transform.localRotation == Quaternion.Euler(transform.right.x, 180, transform.rotation.z))
        {
            hitEnemy = Physics2D.Raycast(transform.position, -transform.right, gunmenzil);
        }
        else if (transform.localRotation == Quaternion.Euler(transform.right.x, -180, transform.rotation.z))
        {
           hitEnemy = Physics2D.Raycast(transform.position, -transform.right, gunmenzil);
        }
        else
        {
            hitEnemy = Physics2D.Raycast(transform.position, transform.right, gunmenzil);
        }

        if (hitEnemy.collider != null)
        {
            Debug.DrawLine(transform.position, hitEnemy.point, Color.red);
            //EnemyFollow();
        }
        else
        {
            Debug.DrawLine(transform.position, hitEnemy.point, Color.green);
        }

    }

}
