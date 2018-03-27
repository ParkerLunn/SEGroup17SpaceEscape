using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTTile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.DisableContinuousEffect(gameObject, 0);
        status.DamageOverTime(gameObject, 10, -1);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.DisableContinuousEffect(gameObject, 2);
    }
}