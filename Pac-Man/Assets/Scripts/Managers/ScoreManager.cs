using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;

    public static ScoreManager Instance { get { return instance; } }
    
    private int score = 0;
    private const string SCORE_TEXT = "Score: ";
    private TextMeshProUGUI scoreGUI;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    
    private void Start()
    {
        scoreGUI = GetComponent<TextMeshProUGUI>();
    }

    public void AddScore(int points)
    {
        score += points;
        SetScoreGUI();
    }

    private void SetScoreGUI()
    {
        scoreGUI.text = SCORE_TEXT + score;
    }

}
