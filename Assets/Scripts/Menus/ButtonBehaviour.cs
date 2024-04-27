using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Menus
{
    public class ButtonBehaviour : MonoBehaviour
    {
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
        /// Quit the game
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}