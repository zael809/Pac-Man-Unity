using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    private const string LIVES_TEXT = "Lives: ";
    private static TextMeshProUGUI livesGUI;

    void Start()
    {
        livesGUI = GetComponent<TextMeshProUGUI>();
    }
    
    public static void UpdateLivesUI(int lives)
    {
        livesGUI.text = LIVES_TEXT + lives;
    }
    
    
    
}
