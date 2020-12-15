using UnityEngine;
using System.Collections;

public class StarPowerUp : MonoBehaviour {

	[SerializeField] private int scorePerHit = 100;
	private scoreBoard scoreBoard;
	
	public GameObject pickupEffect;
	// Use this for initialization
	void Start () {
		
        scoreBoard = FindObjectOfType<scoreBoard>();
	}
	
	private void OnParticleCollision(GameObject other) {
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
		PickUp();
	}
	
	private void PickUp()
    {
		Instantiate(pickupEffect, transform.position, transform.rotation);

        scoreBoard.ScoreHit(scorePerHit);
		Destroy(gameObject);
        
    }
}
