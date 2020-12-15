using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowardsPlayer : MonoBehaviour
{
    float fireRate = 0.2f;
    [SerializeField]Transform shootPoint;
    [SerializeField]GameObject projectile;
    [SerializeField] float turnSpeed = 5;
    Rigidbody rb;
    Transform target;

    void Start(){// Getter the components to implement
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update() {// Change the direction to the players direction
        fireRate -= Time.deltaTime;

        Vector3 direction = transform.position - target.position;
        transform.rotation = Quaternion.Slerp(
            transform.rotation, Quaternion.LookRotation(direction),turnSpeed * Time.deltaTime); 

        if(fireRate <= 0){
            //Change the fireRate
            fireRate = 0.4f;
            Shoot();
        }
    }
    void Shoot(){// Creating a bullet to shoot
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }
}
