using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    public GameObject asteroids;
    public int numOfAsteroids;
    // Start is called before the first frame update
    
    public bool gamePlaying { get; private set; }
    
    void Start()
    {
        gamePlaying = false;
        BeginGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gamePlaying)
        {
            CreateAsteroids();
            
        }
        
        


    }
    private void CreateAsteroids()
    {
        if (Random.Range(0, numOfAsteroids) < 10)
        {
            Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-70.0f, 72.0f),
                                      this.transform.position.y + Random.Range(-20.0f, 20.0f),
                                      this.transform.position.z + Random.Range(100f, 175.0f));

            Instantiate(asteroids, pos, asteroids.transform.rotation);
        }
    }
    private void CreateMine()
    {
        if (Random.Range(0, 600) < 10)
        {
            Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-0f, 0f),
                                      this.transform.position.y + Random.Range(-3f, -3f),
                                      this.transform.position.z + Random.Range(4f, 4f));

            Instantiate(asteroids, pos, asteroids.transform.rotation);
        }
    }
    private void BeginGame()
    {
        gamePlaying = true;
        //startTime = Time.time;
        
    }
}
