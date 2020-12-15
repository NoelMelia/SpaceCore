using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int multiplier;
    public GameObject pickupEffect;
    private void GainHealth(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
