using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class View : MonoBehaviour {

    private Controller ctrl;
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform gameUI;
    private GameObject restartButton;
    private GameObject gameoverUI;
    private GameObject settingUI;
    private GameObject mute;
    private GameObject rankUI;

    private Text score;
    private Text highScore;
    private Text gameoverScore;

    private Text rankScore;
    private Text rankHighScore;
    private Text rankNumbersGame;

    private void Awake()
    {
        ctrl = GameObject.FindGameObjectWithTag("Ctrl").GetComponent<Controller>();

        logoName = transform.Find("Canvas/LogoName") as RectTransform;
        menuUI= transform.Find("Canvas/MenuUI") as RectTransform;
        gameUI = transform.Find("Canvas/GameUI") as RectTransform;
        restartButton = transform.Find("Canvas/MenuUI/ButtonRestart").gameObject;
        gameoverUI = transform.Find("Canvas/GameOverUI").gameObject;
        settingUI = transform.Find("Canvas/SettingUI").gameObject;
        rankUI = transform.Find("Canvas/RankUI").gameObject;

        score = transform.Find("Canvas/GameUI/ScoreLabel/Text").GetComponent<Text>();
        highScore = transform.Find("Canvas/GameUI/HighScoreLabel/Text").GetComponent<Text>();
        gameoverScore = transform.Find("Canvas/GameOverUI/Score").GetComponent<Text>();

        mute = transform.Find("Canvas/SettingUI/AudioButton/mute").gameObject;

        rankScore = transform.Find("Canvas/RankUI/ScoreLabel/Text").GetComponent<Text>();
        rankHighScore = transform.Find("Canvas/RankUI/HighScoreLabel/Text").GetComponent<Text>();
        rankNumbersGame = transform.Find("Canvas/RankUI/NumbersGameLabel/Text").GetComponent<Text>();
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

    public void HideGameoverUI()
    {
        gameoverUI.SetActive(false);
    }

    public void OnHomeButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnSettingButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        settingUI.SetActive(true);
    }

    public void OnSettingUIClick()
    {
        ctrl.audioManager.PlayCursor();
        settingUI.SetActive(false);
    }

    public void SetMuteActive(bool isActive)
    {
        mute.SetActive(isActive);
    }

    public void SetRankUI(int score, int highScore,int numbersGame)
    {
        rankScore.text = score.ToString();
        rankHighScore.text = highScore.ToString();
        rankNumbersGame.text = numbersGame.ToString();
        rankUI.SetActive(true);
    }

    public void OnRankUIClick()
    {
        ctrl.audioManager.PlayCursor();
        rankUI.SetActive(false);
    }
}
