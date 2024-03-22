using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    private bool pauseGame = false;
    // Update is called once per frame
    void Update()
    {
                //Pause Menu
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            pauseGame = !pauseGame;
        }

        if (pauseGame) {
            PauseGame();
        } 
        else {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame() 
    {
        Time.timeScale = 1;
    }
}
