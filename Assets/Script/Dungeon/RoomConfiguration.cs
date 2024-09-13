using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Room configuration")]
public class RoomConfiguration : ScriptableObject
{
    [SerializeField] private Room[] _rooms;
    private Dictionary<string, Room> _idToRoom;

    private void OnEnable()
    {
        _idToRoom = new Dictionary<string, Room>();
        foreach (var room in _rooms)
        {
            _idToRoom.Add(room.Id, room);
        }
    }

    public Room GetRoomPrefabById(string id)
    {
        if (!_idToRoom.TryGetValue(id, out var room))
        {
            throw new System.Exception($"Room with id {id} does not exit");
        }
        return room;
    }
}
