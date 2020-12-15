using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    [Header("Storing Scores")]
    public int score, highScoreNum;
    [Header("Text")]
    public Text scoreText;
    public Text highscore;
    [Header("Instance")]
    public static ScoreBoard instance;
    void Awake() {
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){// Setting up the Score for each game
        score = 0;
        ResetGameScore();
        // Displaying the Highscore and score at start
        scoreText.text = score.ToString();
        highScoreNum = PlayerPrefs.GetInt("HighScore");
        highscore.text = highScoreNum.ToString();
    }

    public static void SetHighScore(int score)
    {// Setting High score in the Player Pref
        if (score > PlayerPrefs.GetInt("HighScore", score))
        {// Setting the value 
            PlayerPrefs.SetInt("HighScore", score);
            
        }
    }

    public void ScoreHit(int inputScore) 
    {//If hit is sucessful then add to score
        score += inputScore;
    }
    void Update()
    {// Update the Highscore if beating
        SetHighScore(score);
        scoreText.text = score.ToString();
        PlayerPrefs.GetInt("Score",score).ToString();
        // Displaying the extra score and added to display score
        if(score > highScoreNum){
            highScoreNum = score;
        }
    }
    public void ResetGameScore(){// Resetting the game score
        PlayerPrefs.SetInt("Score",0);
        score = 0;
    }
}
