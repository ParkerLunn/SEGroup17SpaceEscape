using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour {
    public static SavableStats sStats;
    private int health;

    [SerializeField]
    private float positionX, positionY, positionZ;

	// Use this for initialization
	void Start () {
        sStats = new SavableStats();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("test");
        if (sStats.loaded)
        {
            setPosition();
            sStats.loaded = false;
        }

        positionX = gameObject.transform.position.x;
        positionY = gameObject.transform.position.y;
        positionZ = gameObject.transform.position.z;
        sStats.updatePosition(positionX, positionY, positionZ);
    }

    public void setPosition()
    {
        gameObject.transform.position = sStats.getPosition();
    }
}

[Serializable]
public class SavableStats
{
    [SerializeField]
    private float positionX, positionY, positionZ;

    [NonSerialized]
    public Boolean loaded;

    public void updatePosition(float x, float y, float z)
    {
        positionX = x;
        positionY = y;
        positionZ = z;
    }

    public Vector3 getPosition()
    {
        return new Vector3(positionX, positionY, positionZ);
    }
}
