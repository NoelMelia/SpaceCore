using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float speed = 500f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = target.position - transform.position;
        rigidbody.AddForce(direction * speed * Time.deltaTime);
    }
}
