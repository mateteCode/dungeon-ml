using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : ICreatable
{
    IBoardCreatable _boardManager;
    IDungeonConfiguration _roomConfiguration;
    public DungeonManager(IBoardCreatable boardManager, IDungeonConfiguration roomConfiguration)
    {
        _boardManager = boardManager;
        _roomConfiguration = roomConfiguration;
    }
    public void Create()
    {
        for (int i = 0; i < _roomConfiguration.Size.x; i++)
        {
            for (int j = 0; j < _roomConfiguration.Size.y; j++)
            {
                Cell currentCell = _boardManager.Board[Mathf.FloorToInt(i + j * _roomConfiguration.Size.x)];

                if (currentCell.Visited)
                {
                    int randomRoom = Random.Range(0, _roomConfiguration.PrefabsCount);

                    //GameObject newRoom = Instantiate(_rooms[randomRoom], new Vector3(i * _offset.x, 0f, -j * _offset.y), Quaternion.identity) as GameObject;
                    Room newRoom = Object.Instantiate(_roomConfiguration.GetRoomPrefabById(randomRoom.ToString()), new Vector3(i * _roomConfiguration.Offset.x, 0f, -j * _roomConfiguration.Offset.y), Quaternion.identity);
                    RoomBehaviour rb = newRoom.gameObject.GetComponent<RoomBehaviour>();
                    rb.UpdateRoom(currentCell.DoorStatus);

                    //newRoom.name += " " + i + "-" + j;
                }
            }
        }

    }

}
