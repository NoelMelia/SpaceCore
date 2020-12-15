using UnityEngine;
using System.Collections;

public class LaserPowerUp : MonoBehaviour {

	
	private PlayerFlightControl player;
	public GameObject pickupEffect;
	// Use this for initialization
	void Start () {
		
        player = FindObjectOfType<PlayerFlightControl>();
	}
	
	private void OnParticleCollision(GameObject other) {
		
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
		ProcessHit();
	}
	
	private void ProcessHit()
    {
		Instantiate(pickupEffect, transform.position, transform.rotation);

        player.activate = true;
		Destroy(gameObject);
        
    }
}
