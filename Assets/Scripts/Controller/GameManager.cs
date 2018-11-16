using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool isPause = true;
    public Shape[] shapes;
    public Color[] colors;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (isPause) return;
    }

    public void SpawnShape()
    {
        int index = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);
        Shape shape = Instantiate(shapes[index]);
        shape.init(colors[indexColor]);
    }
}
