using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTile : MonoBehaviour
{


    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.Damage(gameObject, 10);
    }
}
