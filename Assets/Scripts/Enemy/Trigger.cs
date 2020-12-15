using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{    private void OnCollisionEnter(Collision col)
    {// Collision with player or enemy
        //Debug.Log("Hit Collion");
        Destroy(gameObject);
    }
}
