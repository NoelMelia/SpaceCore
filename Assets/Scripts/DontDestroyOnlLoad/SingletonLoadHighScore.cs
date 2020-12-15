using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonLoadHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.instance.highscore = GetComponent<Text>();
        GetComponent<Text>().text = scoreBoard.instance.highScoreNum.ToString();

           }

    
}
