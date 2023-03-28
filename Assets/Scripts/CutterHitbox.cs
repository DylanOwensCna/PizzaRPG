using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterHitbox : MonoBehaviour
{
    public float cutterDamage = 1f;

    public Collider2D cutterCollider;


    // Vector2 rightAttackOffset;
    void Start() {
        if(cutterCollider == null){
            Debug.LogWarning("Cutter Collider not set!");
        }
    }
    
    void OnCollisionEnter2D(Collision2D col){
        col.collider.SendMessage("OnHit", cutterDamage);

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
