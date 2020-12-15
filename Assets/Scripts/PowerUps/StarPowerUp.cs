using UnityEngine;
using System.Collections;

public class StarPowerUp : MonoBehaviour {
	[Header("Score Points")]
	[SerializeField] private int scorePerHit = 100;
	[Header("Calling Other File")]
	private ScoreBoard scoreBoard;
	[Header("Explosion")]
	public GameObject pickupEffect;
	// Use this for initialization
	void Start () {// Getting the scoreboard component
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	private void OnParticleCollision(GameObject other) {// If hit with particle then add on
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
		AddOn();
	}
	private void AddOn()
    {// Destroying the gameobject after being hit with bullet
		Instantiate(pickupEffect, transform.position, transform.rotation);
        scoreBoard.ScoreHit(scorePerHit);// Adding to score
		Destroy(gameObject);
    }
}
