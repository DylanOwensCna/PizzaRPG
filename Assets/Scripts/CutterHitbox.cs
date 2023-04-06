using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterHitbox : MonoBehaviour
{
    public float cutterDamage = 1f;
    public float knockbackForce = 5000f;
    public Collider2D cutterCollider;


    // Vector2 rightAttackOffset;
    void Start() {
        if(cutterCollider == null){
            Debug.LogWarning("Cutter Collider not set!");
        }
    }
    
    void OnTriggerEnter2D(Collider2D col){

    IDamageable damageableObject = col.GetComponent<IDamageable>();
    if(damageableObject != null ) {

    
    Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
        
    Vector2 direction = (Vector2) (col.gameObject.transform.position - parentPosition).normalized;

    Vector2 knockback = direction * knockbackForce;

    damageableObject.OnHit(cutterDamage, knockback);
    } else {
        Debug.LogWarning("Collider does not implement IDamageable");
    }


    }
}
