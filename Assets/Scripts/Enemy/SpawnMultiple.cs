
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
public class SpawnMultiple : MonoBehaviour
{
    
    [Header("Time Field")]
    
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public Text timeText,NumShots;
    /*
    //[SerializeField] private Text timeCounter;
    public float startTime;
    public float elapsedTime;
    public float elapsedTime2;
    public float SpawnTime;
    String timepPlayingStr;
    public TimeSpan timePlaying;
    public float totalTime;
    public static Timer timeAccess;
    */
    
    [Header("Spawning")]
    public GameObject targetParent;
    private int xPos;
    private int yPos;
    [Header("Metrics Info")]
    private float displayCount;
    public float destroyedCount;
    public float shotsFired;
    public float shotsSuccess;
    public static String targetsPer;
    public static String shotsPer;
    public float spawnRate = 0f;
    public bool gamePlaying {get; private set;}
    private bool isSpawning = false;
    
    private void Start() {          
        gamePlaying = false;
        shotsFired = -1;
        spawnRate = 1.0f;
        BeginGame();  
    }


    private void Update() {
        
        if (!isSpawning)
        {
            StartCoroutine(EnemyDrop());
            isSpawning = true;
        }
        if(Input.GetMouseButtonDown(0) )
        {
            shotsFired++;
        }
        if (timerIsRunning )
        { 
            
            if (timeRemaining > 0)
            { 
                
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                NumShots.text = (shotsFired).ToString();
            }
            else{
                timerIsRunning = false;
                timeRemaining = 0;
                Debug.Log("Time has run out!");
                Calculations();
                GameEnd();

            }
        }
        if(shotsSuccess >= 10)
        {
            spawnRate = 0.5f;
        }
        if(shotsSuccess >= 20){
            spawnRate = 0.3f;
        }
    }

    IEnumerator EnemyDrop(){
        while(timeRemaining > 0){ 
            xPos = Random.Range(6, 14);
            yPos = Random.Range(1,9);
            
            Instantiate(targetParent, new Vector3(xPos,yPos,-24),Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
            displayCount++;
        }
    }

    private void OnTargetDestroyedEvent()
    {
        shotsSuccess++;
        destroyedCount++;    
    }
    private void BeginGame()
    {
        gamePlaying = true;
        //startTime = Time.time;
        timerIsRunning = true;
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void Calculations(){
        targetsPer = (((shotsSuccess / shotsFired) * 100) + "%").ToString();
        shotsPer = (((shotsSuccess / displayCount) * 100) + "%").ToString();
        Debug.Log("Shot Accuracy: " + shotsPer);
        Debug.Log("Target Accuracy: " + targetsPer);
    }

    private void GameEnd(){
        
        SceneManager.LoadScene(9);
    }
}
