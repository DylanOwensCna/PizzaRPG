using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Enemy : MonoBehaviour
{
    public float damage = 1;

void OnTriggerEnter2D(Collider2D other) {
    IDamageable damageable = other.GetComponent<IDamageable>();

    if (damageable != null) {
        // Define knockback force
        Vector2 knockbackForce = (other.transform.position - transform.position).normalized * 5f;
        
        // Call OnHit method with damage and knockback force
        damageable.OnHit(damage, knockbackForce);
    }
}
}


