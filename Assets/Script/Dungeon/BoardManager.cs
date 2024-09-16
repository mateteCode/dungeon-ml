using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : IBoardCreatable
{
    public List<Cell> Board { get; private set; }
    IDungeonConfiguration _roomConfiguration;

    public BoardManager(IDungeonConfiguration roomConfiguration)
    {
        _roomConfiguration = roomConfiguration;
    }

    public void Create()
    {
        Board = new List<Cell>();
        float boardLenght = _roomConfiguration.Size.x * _roomConfiguration.Size.y;
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
        if (cell - _roomConfiguration.Size.x >= 0 && !Board[Mathf.FloorToInt(cell - _roomConfiguration.Size.x)].Visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - _roomConfiguration.Size.x));
        }

        //check Down
        if (cell + _roomConfiguration.Size.x < Board.Count && !Board[Mathf.FloorToInt(cell + _roomConfiguration.Size.x)].Visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + _roomConfiguration.Size.x));
        }

        //check Right
        if ((cell + 1) % _roomConfiguration.Size.x != 0 && !Board[Mathf.FloorToInt(cell + 1)].Visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //check Left
        if (cell % _roomConfiguration.Size.x != 0 && !Board[Mathf.FloorToInt(cell - 1)].Visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }
        Debug.Log($"Celda {cell} tiene vecinos vacios en {System.String.Join(", ", neighbors)}");
        return neighbors;
    }
}
