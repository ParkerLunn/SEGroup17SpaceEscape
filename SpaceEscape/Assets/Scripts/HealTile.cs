﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTile : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.DisableContinuousEffect(gameObject, 0);
        status.DamageOverTime(gameObject, -15, 2);

            
        status.DamageOverTime(gameObject, -5f, -1);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.DisableContinuousEffect(gameObject, 2);
    }
}
