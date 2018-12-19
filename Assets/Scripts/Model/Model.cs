using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {

    public const int NORMAL_ROWS = 20;
    public const int MAX_ROWS = 23;
    public const int MAX_COLUMNS = 10;

    private Transform[,] map = new Transform[MAX_COLUMNS, MAX_ROWS];

    private int score = 0;
    private int highScore = 0;
    private int numbersGame = 0;

    public int Score { get { return score; } }
    public int HighScore { get { return highScore; } }
    public int NumbersGame { get { return numbersGame; } }

    public bool isUpdateUI = false;

    private void Awake()
    {
        LoadData();
    }

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

    public bool IsGameOver()
    {
        for (int i = NORMAL_ROWS; i < MAX_ROWS; i++)
        {
            for (int j = 0; j < MAX_COLUMNS; j++)
            {
                if (map[j, i] != null)
                {
                    numbersGame++;
                    SaveData();
                    return true;
                }
            }
        }
        return false;
    }

    public bool RefreshMap(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            map[(int)pos.x, (int)pos.y] = child;
        }
        return CheckMap();
    }

    private bool CheckMap()
    {
        int count = 0;
        for (int i = 0; i < MAX_ROWS; i++)
        {
            if (CheckRowFull(i))
            {
                count++;
                DeleteRow(i);
                MoveDownRowAbove(i + 1);
                i--; //避免同时多行消除的时候只能消除一行
            }
        }
        if (count > 0)
        {
            score += count * 100;
            if(score > highScore)
            {
                highScore = score;
            }
            isUpdateUI = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckRowFull(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] == null) return false;
        }
        return true;
    }

    private void DeleteRow(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            Destroy(map[i, row].gameObject);
            map[i, row] = null;
        }
    }

    private void MoveDownRowAbove(int row)
    {
        for (int i = row; i < MAX_ROWS; i++)
        {
            MoveDownRow(i);
        }
    }

    private void MoveDownRow(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] != null)
            {
                map[i, row - 1] = map[i, row];
                map[i, row] = null;
                map[i, row - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void LoadData()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        numbersGame = PlayerPrefs.GetInt("numbersGame", 0);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.SetInt("numbersGame", numbersGame);
    }
}
