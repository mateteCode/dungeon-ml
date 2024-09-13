using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public bool Visited { get; set; }
    public bool[] DoorStatus { get; set; }

    public Cell()
    {
        Visited = false;
        DoorStatus = new bool[4];
    }
}
