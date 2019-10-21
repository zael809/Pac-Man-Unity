using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManager : MonoBehaviour
{
    private static GameObject player;
    private Vector3 SpawnPos;

    private int lifeCount = 3;

    private void Awake()
    {
        player = gameObject;
    }

    private void Start()
    {
        SpawnPos = player.transform.position;
        EventManager.onDeath += OnDeath;
    }
    
    private void LoseALife()
    {
        lifeCount--;
        if (lifeCount < 0)
        {
            EventManager.RaiseOnGameOver();
            return;
        }
        LivesUI.UpdateLivesUI(lifeCount);
    }

    private void OnDeath()
    {
        player.transform.position = SpawnPos;
        LoseALife();
    }

    public static Transform PacManPosition()
    {
        return player.transform;
    }
}
