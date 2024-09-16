using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DungeonManager : ICreatable
{
    IBoardCreatable _boardManager;
    RoomConfiguration _roomConfiguration;
    IFactory<Room> _roomFactory;
    public DungeonManager(IBoardCreatable boardManager, RoomConfiguration roomConfiguration)
    {
        _boardManager = boardManager;
        _roomConfiguration = roomConfiguration;
        _roomFactory = new RoomFactory((RoomConfiguration) _roomConfiguration);
    }
    public void Create()
    {
        for(int idx=0; idx<_boardManager.Board.Count; idx++)
        {
            Cell currentCell = _boardManager.Board[idx];
            if (currentCell.Visited)
            {
                Room room;
                if (idx == _roomConfiguration.StartPos)
                    room = _roomFactory.Create("StartRoom");
                else if (idx == _roomConfiguration.EndPos)
                    room = _roomFactory.Create("EndRoom");
                else                    
                    room = _roomFactory.Create();

                Room createdRoom = Object.Instantiate(room, _roomConfiguration.GetPosition(idx), Quaternion.identity);
                RoomBehaviour rb = createdRoom.gameObject.GetComponent<RoomBehaviour>();
                rb.UpdateRoom(currentCell.DoorStatus);
            }
                
        }
        _roomConfiguration.CreateCheckPoints();
    }

}
