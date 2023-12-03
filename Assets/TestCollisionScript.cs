using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollisionScript : MonoBehaviour
{

    public ZombieScript zombieScript;
    
    // kill zombie als die wordt geraakt door de bullet
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("geraakt");
        if (zombieScript)
        {
            zombieScript.TakeDamage(10);
        }
    }
}
