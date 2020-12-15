using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [Header("Test Parameters")]
    [SerializeField] private int targetCount;

    [Header("Events")]
    [SerializeField] private UnityEvent onGameOver;

    private int targetsRemaining;
    private int shotsFired;

    public int TargetsRemaining
    {
        get => targetsRemaining;
    }

    public int ShotsFired
    {
        get => shotsFired;
        set => shotsFired = value;
    }

    void Start()
    {
        targetsRemaining = targetCount;
    }

    

    private void OnTargetDestroyedEvent()
    {
        targetsRemaining--;

        if (targetsRemaining <= 0)
        {
            onGameOver?.Invoke();
        }
    }
}
