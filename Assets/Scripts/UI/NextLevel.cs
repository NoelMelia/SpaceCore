using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [Header("Level Controller")]
    public int level;
    private void OnTriggerEnter(Collider other)
    {// Trigger if player hits the finish line
        if (other.CompareTag("Player"))
        {// Go to scene number
            //HealthController.instance.currentHealth = HealthController.instance.currentHealth.ToString();
            SceneManager.LoadScene(level); 
        }
    }
}
