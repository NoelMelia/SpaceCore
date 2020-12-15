using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToStart : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private bool freezeTime = true;

    private static bool isReady = false;

    public static bool IsReady
    {
        get => isReady;
    }

    void Start()
    {
        SetReadyStatus(false);
    }

    void Update()
    {
        if (isReady)
        {
            return;
        }
        else if (!PauseMenu.IsPaused && Input.GetButtonDown("Fire1"))
        {
            SetReadyStatus(true);
        }
    }

    private void SetReadyStatus(bool status)
    {
        startUI.SetActive(!status);
        isReady = status;

        if (freezeTime)
        {
            Time.timeScale = status ? 1f : 0f;
        }
    }
}
