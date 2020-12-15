using UnityEngine;
using System.Collections;

public class HealthPowerUp : MonoBehaviour {
	public GameObject pickupEffect;
	private int pickUp;

	private void OnParticleCollision(GameObject other) {// Trigger with particle effect
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
		PickUp();	
	}
	private void PickUp(){// Once the Object is hit the gameobject will be destroyed
		Instantiate(pickupEffect, transform.position, transform.rotation);
        HealthController.instance.currentHealth += 1;
        Destroy(gameObject);// Adding health point to overall health
        Debug.Log("Tried"+HealthController.instance.currentHealth);
    }
}
