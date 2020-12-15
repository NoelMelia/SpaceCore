using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightBehaviour : MonoBehaviour
{
    
    [SerializeField] GameObject[] guns;

    private bool isControlEnabled;

    void Start()
    {
        isControlEnabled = true;    
    }

    void Update()
    {
        if (isControlEnabled)
        {
            ProcessFiring();
        }

    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetGunsAQctive(true);
        }
        else
        {
            SetGunsAQctive(false);
        }
    }

    private void SetGunsAQctive(bool active)
    {
        foreach(GameObject gun in guns)
        {
            //gun.SetActive(active);
            var emissionEffect = gun.GetComponent<ParticleSystem>().emission;
            emissionEffect.enabled = active;
        }
    }

    private void OnPlayerDeath()    // called by String Reference
    {
        isControlEnabled = false;
        
    }
    
    
}
