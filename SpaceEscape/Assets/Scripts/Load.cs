using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Load{
    public void LoadGame()
    {
        loadPlayer();
    }

    private void loadPlayer()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerStats.dat", FileMode.Open);
        PlayerStats.sStats = (SavableStats)bf.Deserialize(file);
        PlayerStats.sStats.loaded = true;

        file.Close();
    }	
}
