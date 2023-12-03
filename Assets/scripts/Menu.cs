using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // start de game als de play knop in gedrukt is.
    public void startgame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    // stop de game
    public void exitgame()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.UnloadSceneAsync(2);
    }
}
