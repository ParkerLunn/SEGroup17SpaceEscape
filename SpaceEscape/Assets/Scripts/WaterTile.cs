using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : MonoBehaviour {
	// Use this for initialization
	public void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enter collision water");
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.SpeedChange(gameObject, 0.3f, -1);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.DisableContinuousEffect("TilemapFire", 0);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("exit collision water");
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.DisableContinuousEffect(gameObject, 0);
    }
}
