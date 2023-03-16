using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Enemy : MonoBehaviour
{
    public float health = 1f;

    void OnHit(float damage){
        Debug.Log("Mushroom Hit!" + damage);
    }
    public float Health {
        set {
            health = value;
            if(health <=0 ){
                // Defeated();
                Destroy(gameObject);
            }
        }
        get {
            return health;
        }
    }


// public void Defeated(){
//     Destroy(gameObject);
// }
}
