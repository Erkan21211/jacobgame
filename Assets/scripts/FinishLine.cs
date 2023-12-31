using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Text finishText; // De UI Text.

    // triggered als de player de finish line aanraakt
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            finishText.text = "Goed gedaan!";
            PauseGame();
        }
    }

    // game pauze zetten functie
    private void PauseGame()
    {
        Time.timeScale = 0f; // Set time to pause game
    }
}
