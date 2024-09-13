using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager
{
    BoardManager _boardManager;
    Vector2 _dungeonSize;
    public MazeManager(BoardManager boardManager, Vector2 dungeonSize)
    {
        _boardManager = boardManager;
        _dungeonSize = dungeonSize;
    }

    public void Create(int startPos)
    {
        //StarPosition determina el casillero donde el arranca el Dungeon
        int currentCell = startPos;

        //Generamos la Pila(Stack) donde armaremos el Laberinto
        Stack<int> path = new Stack<int>();

        // TODO: Parametrizar el factor de iteraciones
        int maxMazeInteractions = _boardManager.Board.Count * 3;

        for (int k = 0; k < maxMazeInteractions; k++)
        {
            //marca la celda actual como visitada
            _boardManager.Board[currentCell].Visited = true;

            //si se alcanza la celda de salida
            //ser termina el bucle
            if (currentCell == _boardManager.Board.Count - 1)
            {
                break;
            }

            //Check Neighbors cells
            List<int> neighbors = _boardManager.CheckNeighbors(currentCell);
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
                        _boardManager.Board[currentCell].DoorStatus[2] = true;
                        currentCell = newCell;
                        _boardManager.Board[currentCell].DoorStatus[3] = true;
                    }
                    else
                    {
                        // abajo
                        _boardManager.Board[currentCell].DoorStatus[1] = true;
                        currentCell = newCell;
                        _boardManager.Board[currentCell].DoorStatus[0] = true;
                    }
                }
                else
                {
                    //up or left
                    if (newCell + 1 == currentCell)
                    {
                        // izquierda
                        _boardManager.Board[currentCell].DoorStatus[3] = true;
                        currentCell = newCell;
                        _boardManager.Board[currentCell].DoorStatus[2] = true;
                    }
                    else
                    {
                        // arriba
                        _boardManager.Board[currentCell].DoorStatus[0] = true;
                        currentCell = newCell;
                        _boardManager.Board[currentCell].DoorStatus[1] = true;
                    }
                }

            }
        }
    }
}
