using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    private Controller ctrl;

    SpriteRenderer[] renders;

    private bool isPause = false;
    private bool isSpeedup = false;
    private float timer = 0;
    private float stepTime = 0.8f;
    private int multiple = 20;

    private Transform pivot;

    private void Awake()
    {
        renders = GetComponentsInChildren<SpriteRenderer>();
        pivot = transform.Find("Pivot");
    }

    private void Update()
    {
        if (isPause) return;
        timer += Time.deltaTime;
        if(timer >= stepTime)
        {
            timer = 0;
            Fall();
        }
        InputControl();
    }

    public void init(Color color, Controller controller)
    {
        foreach (var block in renders)
        {
            block.color = color;
        }
        this.ctrl = controller;
    }

    private void Fall()
    {
        var pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
        if (!ctrl.model.IsValidMapPosition(transform))
        {
            pos.y += 1;
            transform.position = pos;
            isPause = true;
            ctrl.gameManager.FallDown();
            ctrl.model.RefreshMap(transform);
            return;
        }
        ctrl.audioManager.PlayDrop();
    }

    private void InputControl()
    {
        float h = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            h = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            h = 1;
        }
        if(h != 0)
        {
            Vector3 pos = transform.position;
            pos.x += h;
            transform.position = pos;
            if (!ctrl.model.IsValidMapPosition(transform))
            {
                pos.x -= h;
                transform.position = pos;
            }
            else
            {
                ctrl.audioManager.PlayControl();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(pivot.position, Vector3.forward, -90);
            if (!ctrl.model.IsValidMapPosition(transform))
            {
                transform.RotateAround(pivot.position, Vector3.forward, 90);
            }
            else
            {
                ctrl.audioManager.PlayControl();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isSpeedup = true;
            stepTime /= multiple;
        }
    }

    public void PauseFall()
    {
        isPause = true;
    }

    public void ResumeFall()
    {
        isPause = false;
    }
}
