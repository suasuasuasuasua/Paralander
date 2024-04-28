using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBehavior : MonoBehaviour
{
    public GameObject tutorialPanel;  // Assign the panel in the inspector

    void Start()
    {
        // Check if the tutorial has been shown before
        if (PlayerPrefs.GetInt("TutorialShown") == 0)
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0;  // Pauses the game
        }
    }

    
    public void ClosePanelGoToGame()
    {
        tutorialPanel.SetActive(false);

        Time.timeScale = 1;  // Resumes the game
        PlayerPrefs.SetInt("TutorialShown", 1);  // Set tutorial as shown
        PlayerPrefs.Save();  // Save the player prefs
    }

        public void ClosePanelQuit()
    {
        tutorialPanel.SetActive(false);
        Application.Quit();
    }
}
