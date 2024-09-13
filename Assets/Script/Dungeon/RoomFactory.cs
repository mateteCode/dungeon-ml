using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFactory
{
    readonly RoomConfiguration _roomConfiguration;

    public RoomFactory(RoomConfiguration roomConfiguration)
    {
        _roomConfiguration = roomConfiguration;
    }


    public Room Create(string id)
    {
        var prefab = _roomConfiguration.GetRoomPrefabById(id);
        //return UnityEngine.Object.Instantiate(prefab);
        return prefab;
    }
}
