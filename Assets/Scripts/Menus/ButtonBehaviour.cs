using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Menus
{
    public class ButtonBehaviour : MonoBehaviour
    {
        public GameObject tutorialPanel;

        /// <summary>
        /// Load a scene by name.
        /// 
        /// On each button in the UI, define the name of the scene to load in the
        /// Unity editor.
        /// </summary>
        /// <param name="name"></param>
        public void LoadScene(string name)
        {
            try
            {
                Debug.Log("Attempting to load scene: " + name);
                SceneManager.LoadScene(name);
                Debug.Log("Scene load command sent");
            }
            catch (Exception ex)
            {
                Debug.LogError("Failed to load scene: " + ex.ToString());
            }
        }

        /// <summary>
        /// Accept the tutorial and make the mouse go away
        /// </summary>
        public void AcceptTutorial()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Make the tutorial panel invisible
            tutorialPanel.SetActive(false);

            Time.timeScale = 1;
        }

        /// <summary>
        /// Quit the game
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}