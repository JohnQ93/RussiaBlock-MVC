using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    private Controller ctrl;

    SpriteRenderer[] renders;

    private bool isPause = false;
    private float timer = 0;
    private float stepTime = 0.8f;

    private void Awake()
    {
        renders = GetComponentsInChildren<SpriteRenderer>();
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
        Debug.Log(Input.GetAxisRaw("Horizontal"));
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
        float h = Input.GetAxisRaw("Horizontal");
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
