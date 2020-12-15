using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour
{
    public Slider slider;
    public static HealthBar instance;
    
    private void Awake() {// instance of file
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void SetMaxHealth(int health){// Setting the Max Health to value of health inserted
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health){// Setting the up health inserted
        slider.value = health;
    }
    
}
