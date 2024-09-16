//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{  
    [SerializeField] RoomConfiguration _roomConfiguration;
    IBoardCreatable _boardManager;
    ICreatable _mazeManager;
    ICreatable _dungeonManager;
    public event Action<Vector3> OnMazeCreated;

    private void Awake()
    {
        _boardManager = new BoardManager(_roomConfiguration);
        _mazeManager = new MazeManager(_boardManager, _roomConfiguration);
        _dungeonManager = new DungeonManager(_boardManager, _roomConfiguration);
    }

    public void MazeGenerator()
    {
        //Create Dungeon board
        _boardManager.Create();

        //Create Dungeon Maze
        _mazeManager.Create();

        //Instantiate rooms
        _dungeonManager.Create();

        //Avisames a los subcriptores que el laberinto se ha creado completamnete
        OnMazeCreated?.Invoke(_roomConfiguration.GetPosition(_roomConfiguration.StartPos));
    }

    
    
}
