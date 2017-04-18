using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public bool gameStarted, gameRestarted;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    void Awake()
    {
        CreateSingleton();
    }

    private void Start()
    {
        SetInitialPreferences();
    }

    void CreateSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void SetInitialPreferences()
    {
        if (Preferences.GetEasyDifficulty() != 1 && Preferences.GetMediumDifficulty() != 1 && Preferences.GetHardDifficulty() != 1)
        {
            Preferences.SetEasyDifficulty(1);
            Preferences.SetMediumDifficulty(0);
            Preferences.SetHardDifficulty(0);
            Preferences.SetEasyDifficultyHighscore(0);
            Preferences.SetEasyDifficultyCoinScore(0);
            Preferences.SetMediumDifficultyHighscore(0);
            Preferences.SetMediumDifficultyCoinScore(0);
            Preferences.SetHardDifficultyHighscore(0);
            Preferences.SetHardDifficultyCoinScore(0);
            Preferences.SetMusicStatus(1);
        }
    }

    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            if(gameRestarted)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoins(coinScore);
                GameplayController.instance.SetLives(lifeScore);

                PlayerScore.score = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }
            else if(gameStarted)
            {
                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoins(0);
                GameplayController.instance.SetLives(2);

                PlayerScore.score = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;
            }
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if(lifeScore < 0)
        {
            gameStarted = gameRestarted = false;

            if(Preferences.GetEasyDifficulty() == 1)
            {
                if (score > Preferences.GetEasyDifficultyHighscore())
                    Preferences.SetEasyDifficultyHighscore(score);
                if (coinScore > Preferences.GetEasyDifficultyCoinScore())
                    Preferences.SetEasyDifficultyCoinScore(coinScore);
            }
            else if (Preferences.GetMediumDifficulty() == 1)
            {
                if (score > Preferences.GetMediumDifficultyHighscore())
                    Preferences.SetMediumDifficultyHighscore(score);
                if (coinScore > Preferences.GetMediumDifficultyCoinScore())
                    Preferences.SetMediumDifficultyCoinScore(coinScore);
            }
            else if (Preferences.GetHardDifficulty() == 1)
            {
                if (score > Preferences.GetHardDifficultyHighscore())
                    Preferences.SetHardDifficultyHighscore(score);
                if (coinScore > Preferences.GetHardDifficultyCoinScore())
                    Preferences.SetHardDifficultyCoinScore(coinScore);
            }

            GameplayController.instance.GameOver(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameRestarted = true;
            gameStarted = false;

            GameplayController.instance.RestartGame();
        }
    }
}
