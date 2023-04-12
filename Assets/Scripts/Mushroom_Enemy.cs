using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Enemy : MonoBehaviour
{

    public float damage = 1;

void OnTriggerEnter2D(Collider2D other) {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.OnHit(damage);
        }
    }

}