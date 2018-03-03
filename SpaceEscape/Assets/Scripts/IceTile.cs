using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        other.sharedMaterial.friction = other.sharedMaterial.friction * 0.1f;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.sharedMaterial.friction = other.sharedMaterial.friction * 10f;
    }
}
