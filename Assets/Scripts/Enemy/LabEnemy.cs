using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabEnemy : MonoBehaviour
{

    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parentItem;
    [SerializeField] float EnemyHealth = 10;
    //[SerializeField] float damage = 2;
    private bool EnemyDead = false;
    [SerializeField]int scoreValue;
    private scoreBoard scoreBoard;

    void Start()
    {
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = false;
        
    }

    private void OnParticleCollision(GameObject collision)
    {
        scoreBoard.ScoreHit(scoreValue);
        Debug.Log("Hit");
        
        //TakeDamage(1);
    }
    private void Update() {
        if(EnemyDead == true){
            Debug.Log("Score "+ scoreValue);
            
        }
    }
    
    private void TakeDamage(int damage, int scoreValue){
        EnemyHealth -= damage;
        Debug.Log("Health "+ EnemyHealth);
        if(EnemyHealth <= 0)
        {
            
            Debug.Log("Inside Score "+ scoreValue);
            EnemyDead = true;
            Destroy(gameObject);
        }
    }
}
