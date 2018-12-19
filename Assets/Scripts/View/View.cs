using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class View : MonoBehaviour {

    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform gameUI;
    private GameObject restartButton;
    private GameObject gameoverUI;

    private Text score;
    private Text highScore;
    private Text gameoverScore;

    private void Awake()
    {
        logoName = transform.Find("Canvas/LogoName") as RectTransform;
        menuUI= transform.Find("Canvas/MenuUI") as RectTransform;
        gameUI = transform.Find("Canvas/GameUI") as RectTransform;
        restartButton = transform.Find("Canvas/MenuUI/ButtonRestart").gameObject;
        gameoverUI = transform.Find("Canvas/GameOverUI").gameObject;

        score = transform.Find("Canvas/GameUI/ScoreLabel/Text").GetComponent<Text>();
        highScore = transform.Find("Canvas/GameUI/HighScoreLabel/Text").GetComponent<Text>();
        gameoverScore = transform.Find("Canvas/GameOverUI/Score").GetComponent<Text>();
    }

    public void ShowMenuUI()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(-185.2f, 0.5f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(76.6f, 0.5f);
    }

    public void HideMenuUI()
    {
        logoName.DOAnchorPosY(185.15f, 0.5f)
                .OnComplete(delegate { logoName.gameObject.SetActive(false); });
        menuUI.DOAnchorPosY(-76.55f, 0.5f)
                .OnComplete(delegate { menuUI.gameObject.SetActive(false); });
    }

    public void ShowGameUI(int score, int highScore)
    {
        UpdateGameUI(score, highScore);
        gameUI.gameObject.SetActive(true);
        gameUI.DOAnchorPosY(-128.7f, 0.5f);
    }

    public void HideGameUI()
    {
        gameUI.DOAnchorPosY(128.65f, 0.5f)
              .OnComplete(delegate { gameUI.gameObject.SetActive(false); });
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void UpdateGameUI(int score, int highScore)
    {
        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();
    }

    public void ShowGameoverUI(int score)
    {
        gameoverScore.text = score.ToString();
        gameoverUI.SetActive(true);
    }
}
