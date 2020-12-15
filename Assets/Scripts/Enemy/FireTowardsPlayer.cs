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
    

    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        
        //Destroy(gameObject, 3f);
    }
    private void Update() {
        fireRate -= Time.deltaTime;

        Vector3 direction = transform.position - target.position;
        transform.rotation = Quaternion.Slerp(
            transform.rotation, Quaternion.LookRotation(direction),turnSpeed * Time.deltaTime); 

        if(fireRate <= 0){
            //Chanange the fireRate
            fireRate = 0.4f;
            Shoot();
        }
    }

    void Shoot(){
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }
}
