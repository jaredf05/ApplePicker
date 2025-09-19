using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    void Start()
    {
        // Freeze the game when the scene loads
        Time.timeScale = 0f; 
        Basket.gameStarted = false;  // Stop basket from moving 
    }

    public void StartGame()
    {
        // Hide the start screen overlay
        gameObject.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;

        Basket.gameStarted = true;   //  Allow basket to move
    }
}

