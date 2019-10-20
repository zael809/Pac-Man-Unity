using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            EventManager.RaiseOnDeath();
        }
    }
}
