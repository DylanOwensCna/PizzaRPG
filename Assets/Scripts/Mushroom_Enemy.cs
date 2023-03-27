using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Enemy : MonoBehaviour
{

public float Health {
        set {
            _health = value;
            if(_health <=0 ){
                // Defeated();
                Destroy(gameObject);
            }
        }
        get {
            return _health;
        }
    }

    public float _health = 1;

    void OnHit(float damage){
        Debug.Log("Mushroom Hit for: " + damage);
        Health -= damage;
    }
    


// public void Defeated(){
//     Destroy(gameObject);
// }
}
