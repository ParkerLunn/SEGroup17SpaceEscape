using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;

	public bool isPaused;
	public bool isInventoryOpen;
	public GameObject pauseMenuCanvas;
	public GameObject inventoryCanvas;

	// Update is called once per frame
	void Update () {

		if (isInventoryOpen) {
			inventoryCanvas.SetActive (true);
			pauseMenuCanvas.SetActive (false);
		}

		else if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} 

		else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			isPaused = !isPaused;
			isInventoryOpen = false;
			inventoryCanvas.SetActive (false);
		}
	}

	public void Resume()
	{
		isPaused = false;
	}

	public void Quit()
	{
		Application.LoadLevel (mainMenu);
	}

	public void Inventory() 
	{
		isInventoryOpen = true;
	}
}