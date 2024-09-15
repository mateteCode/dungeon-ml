//using System;
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

    private void Awake()
    {
        _boardManager = new BoardManager(_roomConfiguration);
        _mazeManager = new MazeManager(_boardManager, _roomConfiguration);
        _dungeonManager = new DungeonManager(_boardManager, _roomConfiguration);
    }

    void Start()
    {
        MazeGenerator();
    }


    public void MazeGenerator()
    {
        //Create Dungeon board
        _boardManager.Create();

        //Create Dungeon Maze
        _mazeManager.Create();

        //Instantiate rooms
        _dungeonManager.Create();
    }

    private void OnGUI() 
    {
        float w = Screen.width/2;
        float h = Screen.height - 80;
        if(GUI.Button(new Rect(w,h,250,50), "Regenerate Dungeon"))
        {
            RegenerateDungeon();
        }
    }

    void RegenerateDungeon()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
