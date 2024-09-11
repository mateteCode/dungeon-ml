//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
    }
    
    [SerializeField] Vector2 _dungeonSize;
    [SerializeField] int _startPos = 0;

    [SerializeField] GameObject[] _rooms;
    [SerializeField] Vector2 offset;
    
    List<Cell> _board;

    void Start()
    {
        MazeGenerator();
    }

    void CreateBoard()
    {
        _board = new List<Cell>();
        float boardLenght = _dungeonSize.x * _dungeonSize.y;
        for (int i = 0; i < boardLenght; i++)
        {
            _board.Add(new Cell());
        }
    }

    void CreateMaze()
    {
        //StarPosition determina el casillero donde el arranca el Dungeon
        int currentCell = _startPos;

        //Generamos la Pila(Stack) donde armaremos el Laberinto
        Stack<int> path = new Stack<int>();

        // TODO: Parametrizar el factor de iteraciones
        int maxMazeInteractions = _board.Count * 3;

        for (int k = 0; k < maxMazeInteractions; k++)
        {
            //marca la celda actual como visitada
            _board[currentCell].visited = true;

            //si se alcanza la celda de salida
            //ser termina el bucle
            if (currentCell == _board.Count - 1)
            {
                break;
            }

            //Check Neighbors cells
            List<int> neighbors = CheckNeighbors(currentCell);
            // TODO: Factorizar el if if
            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                if (newCell > currentCell)
                {
                    //down or right
                    if (newCell - 1 == currentCell)
                    {
                        //derecha
                        _board[currentCell].status[2] = true;
                        currentCell = newCell;
                        _board[currentCell].status[3] = true;
                    }
                    else
                    {
                        // abajo
                        _board[currentCell].status[1] = true;
                        currentCell = newCell;
                        _board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    //up or left
                    if (newCell + 1 == currentCell)
                    {
                        // izquierda
                        _board[currentCell].status[3] = true;
                        currentCell = newCell;
                        _board[currentCell].status[2] = true;
                    }
                    else
                    {
                        // arriba
                        _board[currentCell].status[0] = true;
                        currentCell = newCell;
                        _board[currentCell].status[1] = true;
                    }
                }

            }
        }
    }


    void GenerateDungeon()
    {
        for(int i = 0; i < _dungeonSize.x; i++)
        {
            for(int j = 0; j < _dungeonSize.y; j++)
            {
                Cell currentCell = _board[Mathf.FloorToInt(i+j*_dungeonSize.x)];

                if(currentCell.visited)
                {
                    int randomRoom = Random.Range(0,_rooms.Length) ;

                    GameObject newRoom =   Instantiate(_rooms[randomRoom], new Vector3(i * offset.x, 0f, -j * offset.y),Quaternion.identity) as GameObject;
                    RoomBehaviour rb = newRoom.GetComponent<RoomBehaviour>();
                    rb.UpdateRoom(currentCell.status);

                    newRoom.name += " " + i + "-" + j;
                }
            }
        }

    }

    public void MazeGenerator()
    {
        //Create Dungeon board
        CreateBoard();

        //Create Dungeon Maze
        CreateMaze();

       //Instantiate rooms
        GenerateDungeon();
      
    }



    
    //Chequea las celdas vecinas
    List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();
        
        //check Up
        if(cell - _dungeonSize.x >= 0 && !_board[Mathf.FloorToInt(cell - _dungeonSize.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - _dungeonSize.x));
        }
        
        //check Down
        if(cell + _dungeonSize.x < _board.Count && !_board[Mathf.FloorToInt(cell + _dungeonSize.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + _dungeonSize.x));
        }

        //check Right
        if((cell + 1) % _dungeonSize.x != 0 && !_board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //check Left
        if(cell % _dungeonSize.x != 0 && !_board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }
        Debug.Log($"Celda {cell} tiene vecinos vacios en {System.String.Join(", ", neighbors)}");
        return neighbors;
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
