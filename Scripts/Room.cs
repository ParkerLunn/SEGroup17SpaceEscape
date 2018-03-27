using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room: ScriptableObject{

    public GameObject room;

    public bool NDoor, WDoor, SDoor, EDoor;

    public Vector3 npos, spos, wpos, epos;

    public void SetRoom(GameObject _room)
    {
        room = _room;
        HasDoor();
        SetPosition();
    }



    void HasDoor()
    {
        if (room.transform.Find("Transition").Find("DoorNorth") != null)
        {
            NDoor = true;
        }

        else NDoor = false;

        if (room.transform.Find("Transition").Find("DoorSouth") != null)
        {
            SDoor = true;
        }

        else SDoor = false;

        if (room.transform.Find("Transition").Find("DoorEast") != null)
        {
            EDoor = true;
        }

        else EDoor = false;

        if (room.transform.Find("Transition").Find("DoorWest") != null)
        {
            WDoor = true;
        }

        else WDoor = false;
    }

    private void SetPosition()
    {
        if (NDoor)
        {
            npos.y = room.GetComponent<Tiled2Unity.TiledMap>().GetMapHeightInPixelsScaled();
            npos.x = -room.transform.Find("Transition").Find("DoorNorth").localPosition.x;
        }

        if (WDoor)
        {
            wpos.x = -room.GetComponent<Tiled2Unity.TiledMap>().GetMapWidthInPixelsScaled();
        }

        if (EDoor)
        {
            epos.x = room.GetComponent<Tiled2Unity.TiledMap>().GetMapWidthInPixelsScaled();
        }
    }
}
