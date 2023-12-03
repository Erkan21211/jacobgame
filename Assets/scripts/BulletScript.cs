using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            // Code to execute when a bullet hits a zombie
            Debug.Log("Bullet hit zombie!");

            // Get the ZombieScript component from the collided zombie
            ZombieScript zombieScript = other.GetComponent<ZombieScript>();

            // If the ZombieScript component is found, apply damage
            if (zombieScript != null)
            {
                zombieScript.TakeDamage(damage);
            }

            // Destroy the bullet GameObject
            Destroy(gameObject);
        }
    }
}