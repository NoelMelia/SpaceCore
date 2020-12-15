using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    float moveSpeed = 10f;

    Rigidbody rb;

    PlayerFlightControl target;

    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<PlayerFlightControl>();
        //moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        
        //Destroy(gameObject, 3f);
    }
    private void Update() {
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, -100));
        rb.velocity = new Vector3(0, 0, -90);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
