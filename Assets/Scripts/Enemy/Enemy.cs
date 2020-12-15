
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    
    [SerializeField] private int scorePerHit = 2;
    [SerializeField] private int hits = 10;
    [SerializeField] private GameObject explosion;
    private bool finish;

    private scoreBoard scoreBoard;
    //Transform target;

    private void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<scoreBoard>();
        //target = GameObject.FindGameObjectWithTag("MotherShip").transform;
        finish = false;
    }
    void Update()
    {
        if(finish){
            SceneManager.LoadScene(0);
        }


    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hits <= 0)
        {
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
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }
    private IEnumerator EndGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game End");
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(false);
        //SceneManager.LoadScene(0);
    }
}
