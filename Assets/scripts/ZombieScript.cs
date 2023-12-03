using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

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

    void Die()
    {
        Debug.Log("Zombie died");

        // Add any death animations, effects, or logic here.
        Destroy(gameObject);
    }
    
}
