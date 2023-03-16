using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterAttack : MonoBehaviour
{
    public Collider2D cutterCollider;

    public float damage = 2;

    Vector2 rightAttackOffset;
    private void Start() {
        rightAttackOffset = transform.position;
    }


    public void AttackRight() {
        print("Attack Right");
        cutterCollider.enabled=true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft(){
        print("Attack Left");

        cutterCollider.enabled=true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        cutterCollider.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null){
                enemy.Health -= damage;
            }
        }
    }
}
