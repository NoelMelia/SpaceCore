using UnityEngine;
using System.Collections;

public class HealthPowerUp1 : MonoBehaviour {
	public bool activate;
	public GameObject pickupEffect;
	private int pickUp;
	// Use this for initialization
	void Start () {
		//activate = false;
	}
	private void OnParticleCollision(GameObject other) {
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
		PickUp();
		
		
	}
	
	private void PickUp()
    {
		//Health.instance.GainHealth();
		Instantiate(pickupEffect, transform.position, transform.rotation);

        
        Health.instance.currentHealth += 1;
		
        Destroy(gameObject);
        Debug.Log("Hit Power Up");
        
    }
}
