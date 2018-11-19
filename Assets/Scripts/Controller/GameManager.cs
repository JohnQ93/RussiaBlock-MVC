using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Shape currentShape = null;
    private bool isPause = true;
    public Shape[] shapes;
    public Color[] colors;


    void Update () {
        if (isPause) return;
        if(currentShape == null)
        {
            SpawnShape();
        }
    }

    public void StartGame()
    {
        isPause = false;
    }

    public void PauseGame()
    {
        isPause = true;
    }

    public void SpawnShape()
    {
        int index = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);
        currentShape = Instantiate(shapes[index]);
        currentShape.init(colors[indexColor]);
    }
}
