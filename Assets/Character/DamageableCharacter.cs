using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{

    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    bool isAlive = true;public float Health {
    set {
        if(value < _health) {
            animator.SetTrigger("hit");
        }
        
        _health = value;

        if(_health <= 0) {
            Defeated();
        }
    }
    get {
        return _health;
    }
}

public float _health = 3;
public bool _targetable = true;

public void Start() {
    animator = GetComponent<Animator>();
    animator.SetBool("isAlive", isAlive);
    rb = GetComponent<Rigidbody2D>();
    physicsCollider = GetComponent<Collider2D>();
}

public bool Targetable {
    get {
        return _targetable;
    }
    set {
        _targetable = value;
        physicsCollider.enabled = value;
    }
}

public void OnHit(float damage, Vector2 knockback) {
    Health -= damage;
    rb.AddForce(knockback);
}

public void OnHit(float damage) {
    Health -= damage;
}

public void OnObjectDestroyed() {
    Destroy(gameObject);
}

private void Defeated() {
    Time.timeScale = 0; // Stop the game
    // Show the "Game Over" screen
   
}
}

