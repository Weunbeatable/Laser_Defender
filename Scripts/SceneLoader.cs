using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadNextScene()
    {
        /* declared and defined an integer variable current sceneindex
         * within scene manager class run a method called get active scene
         * and the thihng that we want to know is the current build index 
         * what is the scene we are on.
         * thats the code below
         * Then we want to load the next scene, so load scene (currentsceneindex)
         */
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadStartScene()
    {

        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().RestartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
