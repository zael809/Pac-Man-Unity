using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    [SerializeField]
    private int points = 10;
    private const string PLAYER_TAG = "Player";

    private void Start()
    {
        EventManager.onGameOver += OnReset;
    }

    private void CollectPellet()
    {
        EventManager.RaiseOnScore(points);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            CollectPellet();
        }
    }

    private void OnReset()
    {
        gameObject.SetActive(true);
    }
}
