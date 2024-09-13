using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager
{
    Vector2 _dungeonSize;
    BoardManager _boardManager;
    Vector2 _offset;
    GameObject[] _rooms;
    RoomConfiguration _roomConfiguration;
    public DungeonManager(Vector2 dungeonSize, BoardManager boardManager, Vector2 offset, GameObject[] rooms, RoomConfiguration roomConfiguration)
    {
        _dungeonSize = dungeonSize;
        _boardManager = boardManager;
        _offset = offset;
        _rooms = rooms;
        _roomConfiguration = roomConfiguration;
    }
    public void Create()
    {
        for (int i = 0; i < _dungeonSize.x; i++)
        {
            for (int j = 0; j < _dungeonSize.y; j++)
            {
                Cell currentCell = _boardManager.Board[Mathf.FloorToInt(i + j * _dungeonSize.x)];

                if (currentCell.Visited)
                {
                    int randomRoom = Random.Range(0, _rooms.Length);

                    //GameObject newRoom = Instantiate(_rooms[randomRoom], new Vector3(i * _offset.x, 0f, -j * _offset.y), Quaternion.identity) as GameObject;
                    Room newRoom = Object.Instantiate(_roomConfiguration.GetRoomPrefabById("0"), new Vector3(i * _offset.x, 0f, -j * _offset.y), Quaternion.identity);
                    RoomBehaviour rb = newRoom.gameObject.GetComponent<RoomBehaviour>();
                    rb.UpdateRoom(currentCell.DoorStatus);

                    //newRoom.name += " " + i + "-" + j;
                }
            }
        }

    }

}
