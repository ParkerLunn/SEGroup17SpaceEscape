using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Load{

    public void LoadGame()
    {
        loadPlayer();
		loadPuzzle();
	//	loadInventory ();
    }

    private void loadPlayer()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerStats.dat", FileMode.Open);
        PlayerStats.sStats = (SavableStats)bf.Deserialize(file);
		PlayerStats.sStats.loaded = true;


        file.Close();
    }	

	private void loadPuzzle()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/savePuzzles.dat", FileMode.Open);
		SavePuzzles.sPuzzles = (SavablePuzzles)bf.Deserialize(file);
		SavePuzzles.sPuzzles.loaded = true;
        GameController.getInstance().getInactive().setActive();

		file.Close();
	}
}
