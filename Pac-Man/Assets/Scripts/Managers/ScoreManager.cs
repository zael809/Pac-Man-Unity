using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private const string SCORE_TEXT = "Score: ";
    private TextMeshProUGUI scoreGUI;

    private void Start()
    {
        scoreGUI = GetComponent<TextMeshProUGUI>();
        EventManager.onScore += AddScore;
        EventManager.onGameOver += ResetScore;
    }

    private void AddScore(int points)
    {
        score += points;
        SetScoreGUI();
    }

    private void ResetScore()
    {
        score = 0;
        SetScoreGUI();
    }

    private void SetScoreGUI()
    {
        scoreGUI.text = SCORE_TEXT + score;
    }
}
