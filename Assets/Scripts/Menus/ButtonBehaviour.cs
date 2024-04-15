using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(name);
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