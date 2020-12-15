using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InMenuController : MonoBehaviour
{
    [Header("Menu Option Panels")]
    public string mainMenuScene;
    public GameObject pauseMenu;
    public GameObject soundMenu;
    [Header("Booleans")]
    bool wasLocked = false;
    private static bool isPaused = false;
    [Header("Shortcut")]
    private KeyCode pauseKey = KeyCode.Escape;
    [Header("Volume Details")]
    [SerializeField] private Text volumeText;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume;
    [Header("Calling Other File")]
    private CustomPointer custom;
    [Header("Setting up Instance")]
    public static InMenuController instance;
    private void Awake() {// Setting up an instance of the Class
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start() {// Setting the in game menus off
        isPaused = false;
        pauseMenu.SetActive(false);
    }
    void OnMouseDown()
    {// If left click is pressed
        // Lock the cursor
        Screen.lockCursor = true;
    }
    private void Update() {
        if (Input.GetKeyDown(pauseKey))// Checking to see if the esc key was hit
        {
            SetPauseStatus(!isPaused);
        }
    }
    public static bool IsPaused
    {// getter
        get => isPaused;
    }
    private void UnlockCursor()
    {
        // Make sure the cursor isn't locked if coming from a game scene (FPS controller locks the cursor)
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ReturnToMain()
    {// Quit the game and return to main menu
        SceneManager.LoadScene(mainMenuScene);
    }
    public void ResumeGame()
    {// Resume back to Gameplay
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    private void SetPauseStatus(bool status)
    {// Checking if the game is paused
        Time.timeScale = status ? 0f : 1f;
        pauseMenu.SetActive(status);
        isPaused = status;

        if (status)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Pause() => SetPauseStatus(true);// Setting the Pause menu method to true or false
    public void Resume() => SetPauseStatus(false);
    public void RestartLevel()// Restart Level Button to Level 1
    {
        ScoreBoard.instance.ResetGameScore();
        SceneManager.LoadScene(1);
    }
    public void OptionMenu()// Get the Option Panel and Display
    {
        isPaused = true;
        pauseMenu.SetActive(false);
        soundMenu.SetActive(true);
    }
    // Like the main menu. I created a new Music script to house all these
    public void VolumeSlider(float volume)
    {
        AudioListener.volume = volume;
        volumeText.text = volume.ToString("0.0");
    }
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        Debug.Log(PlayerPrefs.GetFloat("masterVolume"));
        soundMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void BackButton()
    {
        soundMenu.SetActive(false);
        pauseMenu.SetActive(true); 
    }
    public void ResetButton(string GraphicsMenu)
    {
        if (GraphicsMenu == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeText.text = defaultVolume.ToString("0.0");
            VolumeApply();   
        }
    }
}