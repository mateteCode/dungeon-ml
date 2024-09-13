using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner
{
    private readonly RoomFactory _roomFactory;
    public RoomSpawner(RoomFactory roomFactory)
    {
        _roomFactory = roomFactory;
    }

    // Logic

    private void SpawnRoom(string id)
    {
        _roomFactory.Create(id);
    }
}
