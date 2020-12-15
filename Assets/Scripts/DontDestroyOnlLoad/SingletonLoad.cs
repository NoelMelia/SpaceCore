using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonLoad : MonoBehaviour
{
    void Start()
    {// Cretating an Singleton
        // Saving the score data for next level 
        ScoreBoard.instance.scoreText = GetComponent<Text>();
        GetComponent<Text>().text = ScoreBoard.instance.score.ToString();
        
    }
}
