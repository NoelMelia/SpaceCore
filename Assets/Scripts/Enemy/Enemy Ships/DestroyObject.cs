using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [Header("Explosion")]
    GameObject explosionFX;

    void Start()
    {// Getting the components
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {// Destroying if a particle effect hits the enmey
        GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(other);
    }
    
}
