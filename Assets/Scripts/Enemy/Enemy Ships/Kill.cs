using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    [Header("Score Points")]
    [SerializeField] private int scorePerHit = 2;
    [SerializeField] private int hits = 10;
    [Header("Explosion")]
    [SerializeField] private GameObject explosion;
    [Header("Create a List")]
    public List<Transform> items = new List<Transform> ();
    [Header("Get the file")]
    private  ScoreBoard scoreBoard;
    private void Start()
    {// Get the file
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    void Update()
    {
        if (transform.position.z < Camera.main.transform.position.z)
        {// Destroy any object gone past the player ship
            //Debug.Log("Out of Bounds");
            Destroy(gameObject);
        }
    }
    private void OnParticleCollision(GameObject other)
    {// Hit with a particle effect 
        ProcessHit();
        if (hits <= 0)
        {// When the enemy ship is destroyed then they will drop a special loot for the player
        // to enhance performance, health or score
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            // Generate a loot in the list at random and make the object appear
            Instantiate(items[Random.Range(0,items.Count-1)],
            transform.position,Quaternion.identity);
        }
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void ProcessHit()
    {// Add to score if object or enmey is hit
        ScoreBoard.instance.ScoreHit(scorePerHit);
        hits--;
    }
 }
