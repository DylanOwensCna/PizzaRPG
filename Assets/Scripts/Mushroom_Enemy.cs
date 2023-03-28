using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Enemy : MonoBehaviour
{
    Animator animator;

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
            }
            
        }
        get {
            return _health;
        }
    }

    
    public void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
    }

    public float _health = 3;

    void OnHit(float damage){
        Debug.Log("Mushroom Hit for: " + damage);
        Health -= damage;
    }
    


// public void Defeated(){
//     Destroy(gameObject);
// }
}
