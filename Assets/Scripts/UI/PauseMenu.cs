using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;

    private KeyCode pauseKey = KeyCode.Escape;
    private SceneController sc;

    private static bool isPaused = false;

    public static bool IsPaused
    {
        get => isPaused;
    }

    void Start()
    {
        sc = FindObjectOfType<SceneController>();
        menuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            SetPauseStatus(!isPaused);
        }
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause() => SetPauseStatus(true);
    public void Resume() => SetPauseStatus(false);

    public void QuitToMainMenu()
    {
        if (sc)
        {
            Time.timeScale = 1f;
            sc.MainMenu(true);
        }
    }

    private void SetPauseStatus(bool status)
    {
        Time.timeScale = status ? 0f : 1f;
        menuUI.SetActive(status);
        isPaused = status;

        if (status)
        {
            //Screen.lockCursor = true;
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
        }
    }
}
