using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    [SerializeField]
    private int points = 10;
    private const string PLAYER_TAG = "Player";

    private void CollectPellet()
    {
        ScoreManager.Instance.AddScore(points);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            CollectPellet();
        }
    }
}
