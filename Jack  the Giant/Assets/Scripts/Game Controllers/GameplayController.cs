using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

    [SerializeField]
    Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    GameObject pausePanel, gameOverPanel, readyButton;

    public static GameplayController instance;

    void Awake()
    {
        SetInstance();
    }

    void Start()
    {
        Time.timeScale = 0f;
        readyButton.SetActive(true);
    }

    void SetInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetCoins(int coins)
    {
        coinText.text = "x" + coins;
    }

    public void SetLives(int lives)
    {
        lifeText.text = "x" + lives;
    }

    public void StartGame()
    {
        readyButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    
    public void QuitGame()
    {
        FaderScript.instance.LoadLevel("TitleScreen");
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameplay");
    }

    public void GameOver(int score, int coins)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = score.ToString();
        gameOverCoinText.text = coins.ToString();
        StartCoroutine("TitleScreen");
    }

    IEnumerator TitleScreen()
    {
        yield return new WaitForSeconds(3f);
        FaderScript.instance.LoadLevel("TitleScreen");
    }

    IEnumerator RestartGameplay()
    {
        yield return new WaitForSeconds(1f);
        FaderScript.instance.LoadLevel("Gameplay");
    }
}
