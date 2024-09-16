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

    public Room Create()
    {
        int randomIndex = Random.Range(0, _roomConfiguration.PrefabsCount);
        return _roomConfiguration.GetRoomPrefabByIndex(randomIndex);
    }
}
