using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamehameha : MonoBehaviour
{

    [SerializeField] SUPA supa;
    
    public float gunmenzil = 5f;
    Vector2 mousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // sol fare tuþu týklandýðýnda
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
        kamehameha();      
    }

    void kamehameha()
    {
        Vector2 direction = mousePosition - (Vector2)transform.position;
        Vector2 endPoint = mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePosition, gunmenzil);
        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, mousePosition * gunmenzil, Color.green);
        }
    }

}
