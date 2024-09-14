using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDungeonConfiguration
{
    Vector2 Size { get; }
    int StartPos { get; }
    int EndPos { get; }
    Vector2 Offset { get; }

    int PrefabsCount { get; }

    Room GetRoomPrefabById(string id);
    Room GetRoomPrefabByIndex(int index);

}
