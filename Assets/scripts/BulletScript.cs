using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{   
    // schade variable 
    public int damage = 1;

    // Als de bullet in contact komt met de zombie, kill de zombie en geef een score aan player.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
          
            // krijg zombie script met de geraakte zombie.
            ZombieScript zombieScript = other.GetComponent<ZombieScript>();

            // Als de zombieScript is gevonden, geef de zombie schade.
            if (zombieScript != null)
            {
                zombieScript.TakeDamage(damage);
            }

            // verwijder de game object
            Destroy(gameObject);
        }
    }
}