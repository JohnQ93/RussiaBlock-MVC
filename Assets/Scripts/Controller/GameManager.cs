using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Shape currentShape = null;
    private bool isPause = true;
    public Shape[] shapes;
    public Color[] colors;

    private Controller ctrl;

    private void Awake()
    {
        ctrl = transform.GetComponent<Controller>();
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
        currentShape = Instantiate(shapes[index]);
        currentShape.init(colors[indexColor], ctrl);
    }

    public void FallDown()
    {
        currentShape = null;
        if (ctrl.model.isUpdateUI)
        {
            ctrl.view.UpdateGameUI(ctrl.model.Score, ctrl.model.HighScore);
            ctrl.model.isUpdateUI = false;
        }
    }
}
