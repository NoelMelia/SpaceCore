using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonLoadHelath : MonoBehaviour
{
    void Start()
    {// Cretating an Singleton
        // Saving the health data for next level 
        HealthController.instance.amountOfHealth = GetComponent<Text>();
        GetComponent<Text>().text = HealthController.instance.currentHealth.ToString();
    }
}
