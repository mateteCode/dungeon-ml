//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
    
    [SerializeField] Vector2 _dungeonSize;
    [SerializeField] int _startPos = 0;

    [SerializeField] GameObject[] _rooms;
    [SerializeField] Vector2 _offset;

    [SerializeField] RoomConfiguration _roomConfiguration;

    BoardManager _boardManager;
    MazeManager _mazeManager;
    DungeonManager _dungeonManager;

    private void Awake()
    {
        _boardManager = new BoardManager(_dungeonSize);
        _mazeManager = new MazeManager(_boardManager, _dungeonSize);
        _dungeonManager = new DungeonManager(_dungeonSize, _boardManager, _offset, _rooms, _roomConfiguration);
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
        _mazeManager.Create(_startPos);

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
