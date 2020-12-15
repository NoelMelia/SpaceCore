using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    [SerializeField]public Text amountOfHealth;
    [SerializeField] private GameObject gameOverPanel;

    //public bool activate;
    public int multiplier = 1;
    public GameObject pickupEffect;
    public HealthBar healthBar;
    private HealthPowerUp1 pickUp;
    public static Health instance;
    private scoreBoard sc;
    // Start is called before the first frame update

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
    {
        pickUp = FindObjectOfType<HealthPowerUp1>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        amountOfHealth.text =  maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        amountOfHealth.text = currentHealth.ToString();
        if(currentHealth <= 0)
        {
            EndGame(); 
        }
        //AddOn();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        amountOfHealth.text = currentHealth.ToString();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit in Trigger");

            TakeDamage(1);
            //Destroy(gameObject);
        }
        
        
    }
    private void EndGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game End");
        //gameOverPanel.SetActive(true);
        //sc.ResetGameScore();
        
        scoreBoard.instance.ResetGameScore();
        
        SceneManager.LoadScene(0);
    }

    public void GainHealth()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        
        currentHealth += multiplier;
        healthBar.SetHealth(currentHealth);
        amountOfHealth.text = currentHealth.ToString();
        Destroy(gameObject);
        Debug.Log("Hit Power Up");
    }
}
