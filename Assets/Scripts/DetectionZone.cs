using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedObjs = new List<Collider2D>();
    public Collider2D col;
    
    // Dectect when objects enter the range
    void OnTriggerEnter2D(Collider2D collider){
        detectedObjs.Add(collider);

    }
        // Dectect when objects leave the range
    void OnTriggerExit2D(Collider2D collider){
        detectedObjs.Remove(collider);

    }
}
