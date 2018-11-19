using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

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
    }

    public void init(Color color)
    {
        foreach (var block in renders)
        {
            block.color = color;
        }
    }

    private void Fall()
    {
        var pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
    }
}
