﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the pause menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance; // Instance variable that holds the singleton of this class

    public bool isPaused; // Global variable to keep track of whether or not game is paused
    [SerializeField]
    private GameObject pauseMenuUI; // The game object containing the pause menu items

    void Awake()
    {
        /// Setup singleton: Check if the instance has already been set and is not already this class, if true destroy self, otherwise this is the singleton instance
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Set isPaused to false
        isPaused = false;
    }

    // Called when the if else statment is true
    public void Resume()
    {
        // Hide pause menu UI
        pauseMenuUI.SetActive(false);
        // Change timeScale back to 1
        Time.timeScale = 1f;
        // set isPaused to false
        isPaused = false;
    }

    // Called when the if else statment is false
    private void Pause()
    {
        // Show pause menu UI
        pauseMenuUI.SetActive(true);
        // Change timeScale to 0
        Time.timeScale = 0f;
        // set isPaused to true
        isPaused = true;
    }

    // Triggered when the menu button is pressed
    public void LoadMenu()
    {
        // Reset timescale
        Time.timeScale = 1f;
        // Load main menu
        SceneManager.LoadScene("Menu");
    }
}