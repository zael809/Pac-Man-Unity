using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 SpawnPos;

    private int lifeCount = 3;
    
    // Start is called before the first frame update
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
}
