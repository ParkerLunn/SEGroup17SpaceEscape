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
		Application.LoadLevel (loadGame);
	}

	public void QuitGame() 
	{
		Application.Quit ();
	}
}
