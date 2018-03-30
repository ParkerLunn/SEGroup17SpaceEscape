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

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("enter collision water");
        Status status = other.gameObject.GetComponent("Status") as Status;
        if (status.Speed > 2) status.Speed = 2;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("exit collision water");
        Status status = other.gameObject.GetComponent("Status") as Status;
        status.Speed = 10;
    }
}
