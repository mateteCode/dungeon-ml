using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFactory: IFactory<Room>
{
    readonly RoomConfiguration _roomConfiguration;

    public RoomFactory(RoomConfiguration roomConfiguration)
    {
        _roomConfiguration = roomConfiguration;
    }

    public Room Create(string id)
    {
        return _roomConfiguration.GetRoomPrefabById(id);
    }
}
