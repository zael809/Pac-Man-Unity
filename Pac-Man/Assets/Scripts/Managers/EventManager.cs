using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    
    public delegate void OnDeath();
    public static event OnDeath onDeath;
    
    public delegate void OnGameOver();
    public static event OnGameOver onGameOver;
    
    public delegate void OnScore(int points);
    public static event OnScore onScore;
    
    public static void RaiseOnDeath()
    {
        onDeath?.Invoke();
    }
    
    public static void RaiseOnGameOver()
    {
        onGameOver?.Invoke();
    }
    
    public static void RaiseOnScore(int points)
    {
        onScore?.Invoke(points);
    }
}
