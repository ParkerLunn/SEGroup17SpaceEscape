using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour {

	bool isOn = false;
	public GameObject switchOn;
	public GameObject switchOff;
	public GameObject doorOpen;
	public GameObject doorClosed;

	public void TurnSwitchOn() 
	{
		isOn = true;
		switchOn.SetActive (true);
		switchOff.SetActive (false);
		doorOpen.SetActive (true);
		doorClosed.SetActive (false);
	}

	public void TurnSwitchOff()
	{
		isOn = false;
		switchOn.SetActive (false);
		switchOff.SetActive (true);
		doorOpen.SetActive (false);
		doorClosed.SetActive (true);
	}
}
