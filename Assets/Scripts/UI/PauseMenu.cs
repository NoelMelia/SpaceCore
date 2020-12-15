using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject menuUI;
    [Header("Shortcut key")]
    private KeyCode pauseKey = KeyCode.Escape;
    [Header("Calling Other Files")]
    private SceneController sc;

    private static bool isPaused = false;
    public static bool IsPaused
    {// Getting the pause if it paused
        get => isPaused;
    }

    void Start()
    {// Getting the Scenecontroller and setting the menu off
        sc = FindObjectOfType<SceneController>();
        menuUI.SetActive(false);
    }

    void Update()
    {// Checking if the shortcut key is pressed
        if (Input.GetKeyDown(pauseKey))
        {
            SetPauseStatus(!isPaused);
        }
    }

    void OnDisable()
    {// Disable the time and pause
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause() => SetPauseStatus(true);// Pause
    public void Resume() => SetPauseStatus(false);// Resume

    public void QuitToMainMenu()
    {// Quit to Main Menu
        if (sc)
        {
            Time.timeScale = 1f;
            sc.MainMenu(true);
        }
    }

    private void SetPauseStatus(bool status)
    {// Setting the pause menu active or not
        Time.timeScale = status ? 0f : 1f;
        menuUI.SetActive(status);
        isPaused = status;

        if (status)
        {
        }
    }
}
