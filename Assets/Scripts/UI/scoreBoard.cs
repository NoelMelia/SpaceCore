using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreBoard : MonoBehaviour
{
    
    public int score, highScoreNum;
    public Text scoreText;
    public Text highscore;

    // Start is called before the first frame update
    public static scoreBoard instance;
    void Awake() {
        
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    void Start(){
        score = 0;
        ResetGameScore();
        //score = PlayerPrefs.GetInt("Score",0);
        scoreText.text = score.ToString();
        highScoreNum = PlayerPrefs.GetInt("HighScore");
        highscore.text = highScoreNum.ToString();
    }

    public static void SetHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore", score))
        {
            
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void ScoreHit(int inputScore) {
        score += inputScore;
        //scoreText.text = score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        SetHighScore(score);
        scoreText.text = score.ToString();
        PlayerPrefs.GetInt("Score",score).ToString();
        
    }
    public void ResetGameScore(){
        PlayerPrefs.SetInt("Score",0);
        score = 0;
    }
}
