using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    
    [Header("Default Menu Values")]
    [SerializeField] private float defaultVolume;
    

    [Header("Levels To Load")]
    public string _newGameButtonLevel;

    [Header("Menu Number")]
    private int menuNumber;
    

    
    [Header("Main Menu Components")]
    [SerializeField] private GameObject menuDefaultCanvas;
    [SerializeField] private GameObject GeneralSettingsCanvas;

    [SerializeField] private GameObject soundMenu;
    
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private GameObject playerMenu;

    [SerializeField] private GameObject confirmationMenu;

    [Header("Menu Popout Dialogs")]

    [SerializeField] private GameObject newGameDialog;

    [Header("Menu Sliders")]
    [SerializeField] private Text volumeText;
    [SerializeField] private Slider volumeSlider;
    ScoreBoard score;
    private void Start()
    {
        menuNumber = 1;
        UnlockCursor();// Unlock the cursor to click on buttons
    }
    //MAIN SECTION
    public IEnumerator ConfirmationBox()
    {// Activating a confirmation box image when a button is pressed to confirm
        confirmationMenu.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {// Once the Escape key is pressed
            if (menuNumber == 2 || menuNumber == 7 || menuNumber == 8)
            {//Back to Main menu Panel
                GoBackToMainMenu();
                ClickSound();
            }

            else if (menuNumber == 3 || menuNumber == 4)
            {// Back to Option Panel
                GoBackToOptionsMenu();
                ClickSound();
            }

            else if (menuNumber == 5)
            {// Back to GamePlay 
                GoBackToGameplayMenu();
                ClickSound();
            }

            else if (menuNumber == 6)
            {// Bcak to game play
                GoBackToGameplayMenu();
                ClickSound();
            }
            else if (menuNumber == 9)
            {// Back to game play
                GoBackToGameplayMenu();
                ClickSound();
            }
        }
    }

    private void ClickSound()
    {// click sound of buttons
        GetComponent<AudioSource>().Play();
    }

    
    public void MouseClick(string buttonType)
    {
        if (buttonType == "Sound")
        {// Activate the Sound Button Menu
            GeneralSettingsCanvas.SetActive(false);
            soundMenu.SetActive(true);
            menuNumber = 4;
        }// Activate the Credit Button Menu
        if (buttonType == "Credits")
        {
            GeneralSettingsCanvas.SetActive(false);
            creditMenu.SetActive(true);
            menuNumber = 9;
        }// Activate the Players Button Menu
        if (buttonType == "Players")
        {
            GeneralSettingsCanvas.SetActive(false);
            playerMenu.SetActive(true);
            menuNumber = 5;
        }// Quit Game
        if (buttonType == "Exit")
        {
            Debug.Log("YES QUIT!");
            Application.Quit();
        }// Activate the Options Button Menu
        if (buttonType == "Options")
        {
            menuDefaultCanvas.SetActive(false);
            GeneralSettingsCanvas.SetActive(true);
            menuNumber = 2;
        }// Activate the New Game Button Menu
        if (buttonType == "NewGame")
        {
            //score.ResetGameScore();
            menuDefaultCanvas.SetActive(false);
            newGameDialog.SetActive(true);
            menuNumber = 7;
        }
    }
    
    private void UnlockCursor()
    {// Make sure the cursor isn't locked if coming from a game scene (FPS controller locks the cursor)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void VolumeSlider(float volume)
    {// Used for Main Menu to store Sound
        AudioListener.volume = volume;
        volumeText.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {// Apply Volume to the Game and 
        PlayerPrefs.SetFloat("BackgroundPref", AudioListener.volume);
        Debug.Log(PlayerPrefs.GetFloat("BackgroundPref"));
        StartCoroutine(ConfirmationBox());
    }
    public void PlayerApply()
    {// Applying the Background Music 
        PlayerPrefs.SetFloat("BackgroundPref", AudioListener.volume);
        Debug.Log(PlayerPrefs.GetFloat("BackgroundPref"));
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string GraphicsMenu)
    {// Reset button in the Sound Window
        if (GraphicsMenu == "Audio")
        {// Apply all setting of volume to default
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeText.text = defaultVolume.ToString("0.0");
            VolumeApply(); 
        }
    }
    

    
    public void ClickNewGameDialog(string ButtonType)
    {// Confirming to start a New Game or Not
        if (ButtonType == "Yes")
        {// Load the Scene 1
            SceneManager.LoadScene(1);
        }
        if (ButtonType == "No")
        {// Back to Main Menu Panel
            GoBackToMainMenu();
        }
    }
    public void GoBackToOptionsMenu()
    {// Returning to Options window from Sound
        GeneralSettingsCanvas.SetActive(true);
        soundMenu.SetActive(false);
        playerMenu.SetActive(false); 
        creditMenu.SetActive(false);
        VolumeApply();
        menuNumber = 2;
    }

    public void GoBackToMainMenu()
    {// Turning on and off a few panels to go back to main menu panel
        menuDefaultCanvas.SetActive(true);
        newGameDialog.SetActive(false);
        GeneralSettingsCanvas.SetActive(false);
        soundMenu.SetActive(false); 
        menuNumber = 1;
    }

    public void GoBackToGameplayMenu()
    {// Back to gameplay
        menuNumber = 5;
    }

    public void ClickQuitOptions()
    {// Quit the options menu panel
        GoBackToMainMenu();
    }

}