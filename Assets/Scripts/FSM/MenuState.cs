using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState {

    private void Awake()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartButtonClick, StateID.Play);
    }

    public override void DoBeforeEntering()
    {
        ctrl.view.ShowMenuUI();
        ctrl.cameraManager.ZoomOut();
    }

    public override void DoBeforeLeaving()
    {
        ctrl.view.HideMenuUI();
    }

    public void OnStartButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.StartButtonClick);
    }

    public void OnRankButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        ctrl.view.SetRankUI(ctrl.model.Score, ctrl.model.HighScore, ctrl.model.NumbersGame);
    }

    public void OnDestroyData()
    {
        ctrl.audioManager.PlayCursor();
        ctrl.model.ClearData();
        OnRankButtonClick();
    }

    public void OnRestartButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        ctrl.model.Restart();
        ctrl.gameManager.ClearShape();
        fsm.PerformTransition(Transition.StartButtonClick);
    }
}
