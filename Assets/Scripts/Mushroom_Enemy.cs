using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Enemy : MonoBehaviour
{

    public float damage = 1;

    void OnCollisonEnter2D(Collision2D col) {
        Collider2D collider = col.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if(damageable != null) {
            damageable.OnHit(damage);
            
        }
    }

}
