using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour {

    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    //放大
    public void ZoomIn()
    {
        mainCamera.DOOrthoSize(14f, 0.5f);
    }
    //缩小
    public void ZoomOut()
    {
        mainCamera.DOOrthoSize(17f, 0.5f);
    }
}
