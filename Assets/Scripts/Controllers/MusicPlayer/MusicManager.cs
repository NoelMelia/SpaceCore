using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [Header("Strings for Prefs")]
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";

    [Header("AudioSource")]
    private int firstPlayInt;
    public Slider backgroundSlider;
    private float backgroundFloat;
    public AudioSource backgroundAudio;
    private void Start() {
        //Sets the in game sounds of background music
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0){
            backgroundFloat = 0.125f;
            backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref,backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }else{
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;  
        }
    }
    public void SaveSoundSettings(){//Saves the Setting when applied to the slider
        PlayerPrefs.SetFloat(BackgroundPref,backgroundSlider.value);
        //Save the Sound up for future reference
    }
    void OnApplicationFocus(bool focusStatus) {
        if(!focusStatus){
            SaveSoundSettings();
        }
    }
    public void UpdateSound(){//Updates the slider sound value when exitting
        backgroundAudio.volume = backgroundSlider.value;
        
    }
}
