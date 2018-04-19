using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private static GameController current;
    private Save save = new Save();
    private Load load = new Load();
    private SavableStats playerStats;
	
	void Awake () {
		if(current == null)
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(current != this)
        {
            Destroy(gameObject);
        }
	}

    public static GameController getInstance()
    {
        return current;
    }

    public void SaveGame()
    {
        save.SaveGame(playerStats);
        print("Save complete!");
    }

    public void LoadGame()
    {
        load.LoadGame();
        print("Load complete!");
    }

    public void setStats(SavableStats stats)
    {
        playerStats = stats;
    }
}
