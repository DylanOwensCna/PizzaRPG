using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Enemy : MonoBehaviour
{
    public float damage = 1;
    public float moveSpeed = 2.0f;
    public float moveDuration = 2.0f;
    public string playerTag = "Player";

    private Transform playerTransform;

    void Start() {
        // Find the player object with the specified tag
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null) {
            playerTransform = playerObject.transform;
            StartCoroutine(MoveTowardsPlayer());
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            // Ignore collisions with other enemy game objects
            return;
        }

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null) {
            damageable.OnHit(damage);
        }
    }

    IEnumerator MoveTowardsPlayer() {
        // Move towards the player's position for the specified duration
        float elapsedTime = 0.0f;
        while (elapsedTime < moveDuration) {
            Vector2 direction = ((Vector2)playerTransform.position - (Vector2)transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Wait for a short time before moving again
        yield return new WaitForSeconds(0.5f);

        // Restart the movement coroutine
        StartCoroutine(MoveTowardsPlayer());
    }

    public void OnHit(float damage) {
        // Handle damage taken by the enemy
    }
}
