using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // snellheid van player, spring kracht, ground detection.
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    private bool isGrounded = false;
    private Rigidbody2D rb;

    public LayerMask groundLayer; // De Ground layer.

    // kogel variables
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Movement / beweging van player
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Jumping by space / springen via knop spatie 
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // shoot by left click / schieten via knop 'x'
        if (Input.GetKeyDown(KeyCode.X)) // x click triggers shooting.
        {
            Shoot();
        }

    }

    // Schiet functie
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.right * bulletSpeed;

        StartCoroutine(DestroyBulletAfterTime(bullet, 1f));
    }

    // laat kogel verwijderen na paar secondes.
    IEnumerator DestroyBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);

        // kijken of kogel niet null is voordat we de kogel verwijderen.
        if (bullet != null)
        {
            Destroy(bullet);
        }
    }

    // ground detection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

    // Munten oppakken en verwijderen na het oppakken.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            ScoreManagerScript scoreManager = FindObjectOfType<ScoreManagerScript>(); // Find the ScoreManager in the scene.
            if (scoreManager != null)
            {
                scoreManager.CollectCoin(); // roep de functie in aan in andere bestand om munten te geven aan de player
            }

            Destroy(other.gameObject); // Destroy the collected coin GameObject.
        }
    }
}
