using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save{
    //public static List<Game> saves = new List<Game>();

	public void SaveGame(SavableStats stats)
    {
        savePlayer(stats);
    }

    private void savePlayer(SavableStats stats)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerStats.dat");
        bf.Serialize(file, stats);
        file.Close();
    }
}
