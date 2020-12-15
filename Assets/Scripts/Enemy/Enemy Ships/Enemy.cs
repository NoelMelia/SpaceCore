
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    
public class Enemy : MonoBehaviour
{
    [Header("Menu Panel")]
    [SerializeField] private GameObject gameOverPanel;
    [Header("Score and Hit")]
    [SerializeField] private int scorePerHit = 2;
    [SerializeField] private int hits = 10;
    [Header("Explosion")]
    [SerializeField] private GameObject explosion;

    [Header("Boolean")]
    private bool finish;

    [Header("Calling Other Files")]
    private ScoreBoard scoreBoard;

    private void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        //target = GameObject.FindGameObjectWithTag("MotherShip").transform;
        finish = false;
    }
    void Update()
    {// Attached to the Mothership
        if(finish){// Checking to see if the boolean is activated
            SceneManager.LoadScene(0);
        }
    }
    private void OnParticleCollision(GameObject other)
    {// Particle Efeect from Gun fire
        ProcessHit();
        if (hits <= 0)
        {// Setting the endgame to active if there is no more hits on ship
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(gameObject);
            finish = true;
            StartCoroutine(EndGame());
        }
    }
    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    private void ProcessHit()
    {// Adding Score to overall score
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }
    private IEnumerator EndGame()
    {// Endgame when the game is over
        Time.timeScale = 0f;
        Debug.Log("Game End");
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(1f);// waiting 1 second
        gameOverPanel.SetActive(false);
        //SceneManager.LoadScene(0);
    }
}
