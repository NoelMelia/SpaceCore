using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.instance.scoreText = GetComponent<Text>();
        GetComponent<Text>().text = scoreBoard.instance.score.ToString();
        
    }

    
}
