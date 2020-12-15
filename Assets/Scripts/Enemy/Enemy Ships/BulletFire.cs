using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [Header("Speed and rigiidbody")]
    float moveSpeed = 10f;
    Rigidbody rb;
    PlayerFlightControl target;
    // Calling the player for targetting
    void Start()
    {// Getting the component to use in file
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<PlayerFlightControl>();
    }
    private void Update() {// Look in the Direction of player
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, -100));
        rb.velocity = new Vector3(0, 0, -90);
    }

    void OnTriggerEnter(Collider col)
    {// Destroy the object when hit player
        if (col.gameObject.name.Equals("Player"))
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
