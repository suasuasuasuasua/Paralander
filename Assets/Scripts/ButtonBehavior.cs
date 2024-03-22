using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //go to next scene
    public void LoadNextScene()
    {
        // Get the current Scene
        Scene currentScene = SceneManager.GetActiveScene();

        // if on start screen
        if (currentScene.name.Equals("MainMenuScene"))
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        // else if on win screen
        else if (currentScene.name.Equals("WinScene"))
        {
            SceneManager.LoadScene(currentScene.buildIndex - 1);
        }
        // else on lose screen
        else 
        {
            SceneManager.LoadScene(currentScene.buildIndex - 2);
        }

    }

    public void QuitGame() {
        Application.Quit();
    }
}
