using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{


    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hit Collion");
            Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
