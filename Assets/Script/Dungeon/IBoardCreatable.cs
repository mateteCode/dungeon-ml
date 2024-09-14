using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardCreatable : ICreatable
{
    List<Cell> Board { get; }
    List<int> CheckNeighbors(int cell);
}
