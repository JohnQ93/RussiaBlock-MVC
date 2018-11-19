using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [HideInInspector]
    public Model model;
    [HideInInspector]
    public View view;
    [HideInInspector]
    public CameraManager cameraManager;
    [HideInInspector]
    public GameManager gameManager;

    public FSMSystem fsm;

    private void Awake()
    {
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
        cameraManager = GetComponent<CameraManager>();
        gameManager = GetComponent<GameManager>();
    }
    private void Start()
    {
        MakeFSM();
    }

    // Update is called once per frame
    void Update () {

    }

    void MakeFSM()
    {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>();
        foreach (FSMState state in states)
        {
            fsm.AddState(state,this);
        }
        FSMState menuState = GetComponentInChildren<MenuState>();
        fsm.SetCurrentState(menuState);
    }
}
