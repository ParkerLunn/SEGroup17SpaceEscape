using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTile : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.Burn(-0.5f, 0.3f);
    }
}
