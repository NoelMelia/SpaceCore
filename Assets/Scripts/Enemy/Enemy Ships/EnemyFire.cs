using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [Header("Bullet")]
     [SerializeField]GameObject Bullet;
    [Header("Fire Speed and rate")]
    float fireRate;
    float nextFire;

    void Start(){// Setting the values
        fireRate = 2f;
        nextFire = Time.time;
    }

    void Update(){// Accessing method
        CheckIfTimeToFire();
    }
    void CheckIfTimeToFire(){//Creating the bullet object and firing it 
        if(Time.time > nextFire)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    } 
}