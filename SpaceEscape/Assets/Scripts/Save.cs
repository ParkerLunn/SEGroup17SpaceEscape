using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save{
    //public static List<Game> saves = new List<Game>();


	public void SaveGame()
    {
        savePlayer();
		savePuzzle();

		//saveInventory ();
    }

    private void savePlayer()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerStats.dat");
        bf.Serialize(file, PlayerStats.sStats);
        file.Close();
    }

	void savePuzzle()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/savePuzzles.dat");
		bf.Serialize(file, SavePuzzles.sPuzzles);
		file.Close ();
	}
}
