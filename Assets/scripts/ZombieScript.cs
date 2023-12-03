using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    // hoeveel vaak die kan geraakt kan worden
    public int maxHealth = 1;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // functie om schade te verricht op de zombie
    public void TakeDamage(int damage)
    {
        Debug.Log("Zombie took damage: " + damage);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            ScoreManagerScript scoreManager = FindObjectOfType<ScoreManagerScript>();

            // Check if the scoreManager is not null before trying to use it
            if (scoreManager != null)
            {
                scoreManager.addscore();
            }
        }
    }

    // functie om zombie te verwijderen van de scene oftewel killen.
    void Die()
    {
        Destroy(gameObject);
    }
    
}
