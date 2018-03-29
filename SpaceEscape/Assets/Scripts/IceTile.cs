using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : MonoBehaviour {
    float holdval;
    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().inertia = holdval;
    }
}
