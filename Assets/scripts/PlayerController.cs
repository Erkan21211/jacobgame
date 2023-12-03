using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // basics
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    private bool isGrounded = false;
    private Rigidbody2D rb;

    public LayerMask groundLayer; // the Ground layer.

    // shooting
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Movement
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Jumping by space
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // shoot by left click
        if (Input.GetKeyDown(KeyCode.X)) // x click triggers shooting.
        {
            Shoot();
        }

    }

    // shoot function
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.right * bulletSpeed;

        StartCoroutine(DestroyBulletAfterTime(bullet, 1f));
    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);

        // Check if the bullet is not null before attempting to destroy it
        if (bullet != null)
        {
            Destroy(bullet);
        }
    }

    // ground deaction
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

    // pickup coins and remove afterwards
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            ScoreManagerScript scoreManager = FindObjectOfType<ScoreManagerScript>(); // Find the ScoreManager in the scene.
            if (scoreManager != null)
            {
                scoreManager.CollectCoin(); // Call the CollectCoin function in the ScoreManager.
            }

            Destroy(other.gameObject); // Destroy the collected coin GameObject.
        }
    }
}
