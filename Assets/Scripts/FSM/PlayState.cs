﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState {

    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClick, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        ctrl.view.ShowGameUI(ctrl.model.Score, ctrl.model.HighScore);
        ctrl.cameraManager.ZoomIn();
        ctrl.gameManager.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        ctrl.view.HideGameUI();
        ctrl.view.ShowRestartButton();
        ctrl.gameManager.PauseGame();
    }

    public void OnPauseButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.PauseButtonClick);
    }

    public void OnRestartButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        ctrl.view.HideGameoverUI();
        ctrl.model.Restart();
        ctrl.gameManager.StartGame();
        ctrl.view.UpdateGameUI(ctrl.model.Score, ctrl.model.HighScore);
    }
}
