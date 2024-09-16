using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Room configuration")]
public class RoomConfiguration : ScriptableObject, IDungeonConfiguration
{
    [SerializeField] Room[] _rooms;
    private Dictionary<string, Room> _idToRoom;

    [SerializeField] GameObject _bossPointPrefab;
    public GameObject BossPointPrefab => _bossPointPrefab;

    [SerializeField] GameObject _startPointPrefab;
    public GameObject StartPointPrefab => _startPointPrefab;

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

    void OnValidate()
    {
        int size = (int)_size.x * (int)_size.y;
        if (EndPos >= size)
        {
            _endPos = size - 1;
        }
        if(StartPos >= size)
        {
            _startPos = 0;
        }
    }

    public Vector3 GetPosition(int cell)
    {
        float x = (cell % Size.x) * Offset.x;
        float y = - (float) Math.Floor(cell / Size.x) * Offset.y;
        Debug.Log($"La celda {cell} se posiciona en {x}, {y}");
        return new Vector3(x, 0, y);
    }

    public void CreateCheckPoints()
    {
        if (BossPointPrefab != null)
        {
            Vector3 position = GetPosition(EndPos);
            Instantiate(_bossPointPrefab, new Vector3(position.x, 1.5f, position.z), Quaternion.identity);
        }
        if (StartPointPrefab != null)
        {
            Vector3 position = GetPosition(StartPos);
            Instantiate(_startPointPrefab, new Vector3(position.x, 1.5f, position.z), Quaternion.identity);
        }

    }

}
