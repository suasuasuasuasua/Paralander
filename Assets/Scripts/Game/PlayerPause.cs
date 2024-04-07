using UnityEngine;

namespace Game
{
    public class PlayerPause : MonoBehaviour
    {
        private bool pauseGame = false;
        // Update is called once per frame
        void Update()
        {
            // Pause Menu by pressing P
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseGame = !pauseGame;
            }

            // TODO: this logic feels weird because we're constantly setting the
            // time scale to 0 or 1
            // Pause the game
            if (pauseGame)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        /// <summary>
        /// Pause the game by setting the time scale to 0.
        /// TODO: Need to make a more sophisticated pause menu, ideally another
        /// scene or overlay a canvas.
        /// </summary>
        private void PauseGame()
        {
            Time.timeScale = 0;
        }

        /// <summary>
        /// Resume the game by setting the time scale to 1.
        /// </summary>
        private void ResumeGame()
        {
            Time.timeScale = 1;
        }
    }
}