using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    [SerializeField] private int scorePerHit = 2;
    [SerializeField] private int hits = 10;
    [SerializeField] private GameObject explosion;
    //[SerializeField] private Transform parent;
    public List<Transform> items = new List<Transform> ();

    private  scoreBoard scoreBoard;
    //Transform target;

    private void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<scoreBoard>();
        //target = GameObject.FindGameObjectWithTag("MotherShip").transform;
    }
    void Update()
    {
        // Perform logic to move the object, first. That way, it trigers
        // Destroy() as soon as it oversteps its boundary.

        if (transform.position.z < Camera.main.transform.position.z)
        {
            Debug.Log("Out of Bounds");
            Destroy(gameObject);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hits <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
            
            Instantiate(items[Random.Range(0,items.Count-1)],
            transform.position,Quaternion.identity);
            
            //Instantiate(lootDrop,transform.position,Quaternion.identity);
        }
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void Death()
    {
        //GameObject expl = Instantiate(explosion, pos, Quaternion.identity);
        //  explosionInstance.transform.parent = parent;
        
        //Destroy(expl, 2.0f);
        //Destroy(gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.instance.ScoreHit(scorePerHit);
        
        hits--;
    }

    public void EndGame(){

    }
 }
