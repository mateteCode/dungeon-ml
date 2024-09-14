using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Room configuration")]
public class RoomConfiguration : ScriptableObject, IDungeonConfiguration
{
    [SerializeField] Room[] _rooms;
    private Dictionary<string, Room> _idToRoom;

    [SerializeField] Vector2 _size;
    public Vector2 Size => _size;

    [SerializeField] int _startPos;
    public int StartPos => _startPos;

    [SerializeField] int _endPos;
    public int EndPos => _endPos;

    [SerializeField] Vector2 _offset;
    public Vector2 Offset => _offset;

    public int PrefabsCount => _rooms.Length;

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

    public Room GetRoomPrefabByIndex(int index)
    {
        if(index >= _rooms.Length || _rooms[index] == null )
        {
            throw new System.Exception($"Room with index {index} does not exit");
        }
        return _rooms[index];
    }
}
