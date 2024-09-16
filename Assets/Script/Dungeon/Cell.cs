using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public bool Visited { get; set; }
    public bool[] DoorStatus { get; set; }
    public bool[] WallStatus { get; set; }
    public bool[] PillarStatus { get; set; }

    public Cell()
    {
        Visited = false;
        DoorStatus = new bool[4];
        WallStatus = new bool[4];
        PillarStatus = new bool[4];
    }
}
