using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [Header("Health Integers")]
    public int maxHealth = 10;
    public int currentHealth;
    public int multiplier = 1;

    [Header("Text Fields")]
    [SerializeField]public Text amountOfHealth;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Explosion")]
    public GameObject pickupEffect;

    [Header("Calling Other Files")]
    public HealthBar healthBar;
    private HealthPowerUp pickUp;

    [Header("Creating an Instanse")]
    public static HealthController instance;
    private void Awake() {
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {//Setting the Helath details
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        amountOfHealth.text =  maxHealth.ToString();
    }

    void Update()
    {// Update the health displayed on score
        amountOfHealth.text = PlayerPrefs.GetInt("Health", currentHealth).ToString();
        
        if(currentHealth <= 0)
        {// If health is below 0 then the game is over and returned to home screen
            EndGame(); 
        }
    }
    void TakeDamage(int damage)
    {// Take Damage if the enemy hits player
        currentHealth -= damage;// Update the health and take away 
        healthBar.SetHealth(currentHealth);
        amountOfHealth.text = currentHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {// If enemy ships or debris collide with player then take damage
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Hit in Trigger");
            TakeDamage(1);
        }
    }
    private void EndGame()
    {// End game and go back to Main menu
        Time.timeScale = 0f;
        //Debug.Log("Game End");
        
        ScoreBoard.instance.ResetGameScore();//Reset the score
        SceneManager.LoadScene(0);
    }

    /*public void GainHealth()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        
        currentHealth += multiplier;
        healthBar.SetHealth(currentHealth);
        amountOfHealth.text = currentHealth.ToString();
        Destroy(gameObject);
        Debug.Log("Hit Power Up");
    }*/
}
