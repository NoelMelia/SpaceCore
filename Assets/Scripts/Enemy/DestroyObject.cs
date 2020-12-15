using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    GameObject explosionFX;

    void Start()
    {
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(other);
    }
    
}
