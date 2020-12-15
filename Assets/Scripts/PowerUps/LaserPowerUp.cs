using UnityEngine;
using System.Collections;

public class LaserPowerUp : MonoBehaviour {

	[Header("Calling player")]
	private PlayerFlightControl player;
	[Header("Explosion")]
	public GameObject pickupEffect;
	// Use this for initialization
	void Start () {
		// Getting compoment
        player = FindObjectOfType<PlayerFlightControl>();
	}
	private void OnParticleCollision(GameObject other) {
		// When object is hit with particle effect
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
		ProcessHit();
	}
	private void ProcessHit()
    {// Destroy object and send a trigger to the Player to activate the special weapon
		Instantiate(pickupEffect, transform.position, transform.rotation);
        player.activate = true;
		Destroy(gameObject); 
    }
}
