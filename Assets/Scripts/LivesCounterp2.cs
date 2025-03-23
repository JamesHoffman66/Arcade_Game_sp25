using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesCounterp2 : MonoBehaviour
{
    public static LivesCounterp2 instance;
    public TextMeshProUGUI livesText; // Reference to the UI Text
    private int lives = 2;
    public bool gameOver;

    private void Awake()
    {
        instance = this;
        gameOver = false;
    }
    void Start()
    {
        UpdateScoreDisplay();
    }

    // Call this method whenever a pin is hit
    public void DecreaseLives()
    {
        lives -= 1;
        UpdateScoreDisplay();
    }

    // Update the score display text
    private void UpdateScoreDisplay()
    {
        livesText.text = "Player 2 Lives: " + lives;
    }
    public void Update()
    {
        if (lives == 0)
        {
            gameOver = true;
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
