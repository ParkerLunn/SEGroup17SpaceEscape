//This script will procedurally generate the dungeon based on prefab rooms.
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimun; //Min number of rooms in a floor
        public int maximun; //Max number of rooms in a floor

        public Count(int max, int min)
        {
            minimun = min;
            maximun = max;
        }
    }

    public int roomAmount; //amount of rooms this floor will have

    public Count roomCount = new Count(1, 1); //used to get the random value for the amount of rooms

    public List<GameObject> prefabs;

    public List<Room> rooms; //array of gameObjects will hold all the prefab rooms that we will be able to spawn.

    private Transform boardHolder; //Prefabs will be under it, will improve hierarchy readability

    public List<int> choices;

    void BoardSetup()
    {
        for (int i = 1; i < roomAmount; i++)
        {
            int choice = Random.Range(1, roomAmount);
            choices.Add(choice);

            if (i == 1)
                Instantiate(rooms[choice].room, rooms[choice].npos, Quaternion.identity).transform.SetParent(boardHolder);

            else {
                rooms[choice].npos.y += rooms[choices[i - 2]].npos.y;
                Instantiate(rooms[choice].room, rooms[choice].npos, Quaternion.identity).transform.SetParent(boardHolder);
            }
        }
    }

	public void SetUp()
    {
        boardHolder = new GameObject("Board").transform;

        roomAmount = Random.Range(roomCount.minimun, roomCount.maximun + 1);

        for (int i = 0; i < roomAmount; i++)
        {
            rooms.Add(ScriptableObject.CreateInstance<Room>());
            rooms[i].SetRoom(prefabs[0]);
            prefabs.RemoveAt(0);
        }

        Vector3 temp = Vector3.zero;
        temp.x = -rooms[0].room.transform.Find("Transition").Find("DoorNorth").localPosition.x;

        Instantiate(rooms[0].room, temp, Quaternion.identity).transform.SetParent(boardHolder);

        BoardSetup();
    }
}
