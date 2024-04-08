using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class MainMenuButtonBehaviour : MonoBehaviour
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
            // Use the asynchronous version to avoid pauses and perfomrance
            // hiccups
            SceneManager.LoadSceneAsync(name);
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