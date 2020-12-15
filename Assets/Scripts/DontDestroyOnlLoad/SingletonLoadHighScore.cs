using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonLoadHighScore : MonoBehaviour
{
    void Start()
    {// Creating an Singleton
        // Saving the highscore data for next level
        ScoreBoard.instance.highscore = GetComponent<Text>();
        GetComponent<Text>().text = ScoreBoard.instance.highScoreNum.ToString();

    } 
}
