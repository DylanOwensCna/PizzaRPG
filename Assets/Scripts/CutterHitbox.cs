using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterHitbox : MonoBehaviour
{
    public Collider2D cutterCollider;

    public float cutterDamage = 2f;

    // Vector2 rightAttackOffset;
    private void Start() {
        if(cutterCollider == null){
            Debug.LogWarning("Cutter Collider not set!");
        }
        // rightAttackOffset = transform.position;
        cutterCollider.GetComponent<Collider2D>();
    }


    // public void AttackRight() {
    //     print("Attack Right");
    //     cutterCollider.enabled=true;
    //     transform.localPosition = rightAttackOffset;
    // }

    // public void AttackLeft(){
    //     print("Attack Left");

    //     cutterCollider.enabled=true;
    //     transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    // }

    // public void StopAttack() {
    //     cutterCollider.enabled = false;

    // }

    void OnCollisonEnter2D(Collision2D col){
        col.collider.SendMessage("OnHit", cutterDamage);

    }

    // private void OnTriggerEnter2D(Collider2D collider){
    //     collider.SendMessage("OnHit", cutterDamage);
        // if(collider.tag == "Enemy"){
        //     Enemy enemy = collider.GetComponent<Enemy>();

        //     if(enemy != null){
        //         enemy.Health -= damage;
        //     }
        }
    // }
// }
