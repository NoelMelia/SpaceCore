using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    //Singleton
    public static GameContoller instance;

    public GameObject hudContainer, enemyWaves;
    public Text  waveCounter;
    //public Text scoreCounter;
    //public bool gamePlaying {get; private set;}
    
    private int numTotalEnemyWaves, numSlayedEnemies;
    TimeSpan timePlaying;
    //private int score;
    private void Awake() {
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update() {
        //Updates the amount of waves and prints to screen
        waveCounter.text = numTotalEnemyWaves.ToString();
        
    }
    private void Start() {
        //Gets the number of Waves Going Through the Game
        numTotalEnemyWaves = enemyWaves.transform.childCount;
        numSlayedEnemies = 0;
        //score = 0;
        //UpdateScore ();
        
        //gamePlaying = false;
        //StartCoroutine(CountdownToStart());
    }

    
    public void AddScore (int newScoreValue)
    {
        //score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        //scoreCounter.text = score.ToString();
        //PlayerPrefs.SetInt("Score", score); 
    }
}
