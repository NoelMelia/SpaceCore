using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0.65f;
    [SerializeField] GameObject explosionFX;

    private void OnTriggerEnter(Collider other)
    {
        // send a message to the other classes that I got hit.
        SendMessage("OnPlayerDeath");
        StartDeathSequence();
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        explosionFX.SetActive(true);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

}
