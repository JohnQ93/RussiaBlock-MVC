using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {

    public const int MAX_ROWS = 23;
    public const int MAX_COLUMNS = 10;

    private Transform[,] map = new Transform[MAX_COLUMNS, MAX_ROWS];


    public bool IsValidMapPosition(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            if (!IsInsideMap(pos)) return false;  //判断是否在网格内，若不在则返回false
            if (map[(int)pos.x, (int)pos.y] != null) return false;  //判断每个小方格所在位置是否有其他方格存在，若有则返回false
        }
        return true;
    }

    private bool IsInsideMap(Vector2 pos)
    {
        return pos.x >= 0 && pos.x < MAX_COLUMNS && pos.y >= 0;
    }

    public void RefreshMap(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            map[(int)pos.x, (int)pos.y] = child;
        }
    }
}
