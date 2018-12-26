using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Shape currentShape = null;
    private bool isPause = true;
    public Shape[] shapes;
    public Color[] colors;
    private Transform blockHolder;
    private Controller ctrl;

    private void Awake()
    {
        ctrl = transform.GetComponent<Controller>();
        blockHolder = transform.Find("BlockHolder");
    }

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
        if (currentShape != null)
        {
            currentShape.ResumeFall();
        }
    }

    public void PauseGame()
    {
        isPause = true;
        if (currentShape != null)
        {
            currentShape.PauseFall();
        }
    }

    public void SpawnShape()
    {
        int index = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);
        currentShape = Instantiate(shapes[index], blockHolder);
        currentShape.init(colors[indexColor], ctrl);
    }

    public void ClearShape()
    {
        if(currentShape != null)
        {
            Destroy(currentShape.gameObject);
            currentShape = null;
        }
    }

    //方块落到底了，调用一次此方法
    public void FallDown()
    {
        currentShape = null;
        if (ctrl.model.isUpdateUI)
        {
            ctrl.view.UpdateGameUI(ctrl.model.Score, ctrl.model.HighScore);
            ctrl.model.isUpdateUI = false;
        }

        foreach (Transform t in blockHolder)
        {
            if(t.childCount <= 1)
            {
                Destroy(t.gameObject);
            }
        }

        if (ctrl.model.IsGameOver())
        {
            PauseGame();
            ctrl.view.ShowGameoverUI(ctrl.model.Score);
        }
    }
}
