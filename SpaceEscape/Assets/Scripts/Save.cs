using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save{
    public static List<Game> saves = new List<Game>();

	public static void SaveGame()
    {
        saves.Add(GameObject.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.spe");
        bf.Serialize(file, saves);
        file.Close();
    }
}
