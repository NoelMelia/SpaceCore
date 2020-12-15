using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonLoadHelath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Health.instance.amountOfHealth = GetComponent<Text>();
        GetComponent<Text>().text = Health.instance.currentHealth.ToString();

            }

    
}
