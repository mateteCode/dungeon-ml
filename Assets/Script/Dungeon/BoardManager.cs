using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager
{
    public List<Cell> Board { get; private set; }
    Vector2 _dungeonSize;

    public BoardManager(Vector2 dungeonSize)
    {
        _dungeonSize = dungeonSize;
    }

    public void Create()
    {
        Board = new List<Cell>();
        float boardLenght = _dungeonSize.x * _dungeonSize.y;
        for (int i = 0; i < boardLenght; i++)
        {
            Board.Add(new Cell());
        }
    }

    //Chequea las celdas vecinas
    public List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //check Up
        if (cell - _dungeonSize.x >= 0 && !Board[Mathf.FloorToInt(cell - _dungeonSize.x)].Visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - _dungeonSize.x));
        }

        //check Down
        if (cell + _dungeonSize.x < Board.Count && !Board[Mathf.FloorToInt(cell + _dungeonSize.x)].Visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + _dungeonSize.x));
        }

        //check Right
        if ((cell + 1) % _dungeonSize.x != 0 && !Board[Mathf.FloorToInt(cell + 1)].Visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //check Left
        if (cell % _dungeonSize.x != 0 && !Board[Mathf.FloorToInt(cell - 1)].Visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }
        Debug.Log($"Celda {cell} tiene vecinos vacios en {System.String.Join(", ", neighbors)}");
        return neighbors;
    }
}
