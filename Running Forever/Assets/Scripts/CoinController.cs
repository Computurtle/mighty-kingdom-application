﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CoinController : MonoBehaviour
{
    private Rigidbody2D rb; // Variable that holds the Rigidbody2D component of the object it's attached to

    // Get the Rigidbody2D and assign it to the Rigidbody2D variable
    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
    }

    // If active, constantly move the rigidbodies position based on the difficulty
    void Update()
    {
        Vector3 position = new Vector3(transform.position.x - ((DifficultyManager.Instance.difficulty) * Time.deltaTime), transform.position.y, 0f);
        rb.MovePosition(position);
    }

    // Check if the objects position is off screen, if so deactivate the object putting it back into the pool
    void FixedUpdate()
    {
        if (transform.position.x < -16f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with the player
        if (other.tag == "Player")
        {
            // Play SFX, increase ScoreManager's coinScore by the coinScore set in CoinManager
            SFXManager.Instance.coinCollect.Play();
            ScoreManager.Instance.coinScore += CoinManager.Instance.coinScore;
            // Deactivate the object putting it back into the pool
            gameObject.SetActive(false);
        }
    }
}