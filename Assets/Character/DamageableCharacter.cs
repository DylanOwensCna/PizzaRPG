using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{

    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    bool isAlive = true;
public float Health {
        set {
            if(value < _health) {
                animator.SetTrigger("hit");

            _health = value;
            
            }
            if(_health <=0 ){
                // Defeated();
                animator.SetBool("isAlive", false);
                Targetable = false; 
            }
            
        }
        get {
            return _health;
        }
    }

    
    public void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        rb = GetComponent<Rigidbody2D>();

        physicsCollider = GetComponent<Collider2D>();
    }
    
    public bool Targetable { get { return _targetable; }
    set {
        _targetable = value;
        
        physicsCollider.enabled = value;
    } }

    public float _health = 3;
    public bool _targetable = true;

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        // Apply the force to the slime
        rb.AddForce(knockback);
    }

    public void OnHit(float damage)
    {

        Health -= damage;
    }

    public void OnObjectDestroyed() {
        Destroy(gameObject);
    }


}
