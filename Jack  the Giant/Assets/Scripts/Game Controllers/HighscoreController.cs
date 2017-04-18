using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {

    [SerializeField]
    Text highscoreText, coinText;

    private void Awake()
    {
        if (Preferences.GetEasyDifficulty() == 1)
        {
            highscoreText.text = Preferences.GetEasyDifficultyHighscore().ToString();
            coinText.text = Preferences.GetEasyDifficultyCoinScore().ToString();
        }
        else if (Preferences.GetMediumDifficulty() == 1)
        {
            highscoreText.text = Preferences.GetMediumDifficultyHighscore().ToString();
            coinText.text = Preferences.GetMediumDifficultyCoinScore().ToString();
        }
        else if (Preferences.GetHardDifficulty() == 1)
        {
            highscoreText.text = Preferences.GetHardDifficultyHighscore().ToString();
            coinText.text = Preferences.GetHardDifficultyCoinScore().ToString();
        }
    }

	public void TitleScreen()
    {
        FaderScript.instance.LoadLevel("TitleScreen");
    }
}
