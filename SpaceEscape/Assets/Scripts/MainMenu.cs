using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string newGame;
	public string loadGame;

	public void NewGame() 
	{
		Application.LoadLevel (newGame);
	}

	public void LoadGame() 
	{
		//Put code to load last save state in here
	}

	public void QuitGame() 
	{
		Application.Quit ();
	}
}
