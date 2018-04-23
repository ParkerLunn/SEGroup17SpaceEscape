using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SavePuzzles : MonoBehaviour {


	public static SavablePuzzles sPuzzles;
	private bool isActive;
	// Use this for initialization
	void Start () {

		sPuzzles = new SavablePuzzles();
		
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("LOADED????? " + sPuzzles.loaded);
		if (sPuzzles.loaded)
		{
			setVisbility();
			sPuzzles.loaded = false;
		}

		isActive = gameObject.activeSelf;
		sPuzzles.updateVisibility (isActive);
		
	}

	public void setVisbility()
	{
		gameObject.SetActive(sPuzzles.getVisibility());
		Debug.Log ("is it active" + isActive);
	}
}

[Serializable]	
public class SavablePuzzles
{
	[SerializeField]
	private bool isActive;

	[NonSerialized]
	public Boolean loaded;

	public void updateVisibility(bool active)
	{
		isActive = active;
	}

	public bool getVisibility()
	{
		return isActive;
	}
}
