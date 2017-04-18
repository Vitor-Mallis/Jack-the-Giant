using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Preferences {

    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighscore = "EasyDifficultyHighscore";
    public static string MediumDifficultyHighscore = "MediumDifficultyHighscore";
    public static string HardDifficultyHighscore = "HardDifficultyHighscore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

    public static void SetEasyDifficulty(int value)
    {
        PlayerPrefs.SetInt(Preferences.EasyDifficulty, value);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(Preferences.EasyDifficulty);
    }

    public static void SetMediumDifficulty(int value)
    {
        PlayerPrefs.SetInt(Preferences.MediumDifficulty, value);
    }

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(Preferences.MediumDifficulty);
    }

    public static void SetHardDifficulty(int value)
    {
        PlayerPrefs.SetInt(Preferences.HardDifficulty, value);
    }

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(Preferences.HardDifficulty);
    }

    public static void SetEasyDifficultyHighscore(int value)
    {
        PlayerPrefs.SetInt(Preferences.EasyDifficultyHighscore, value);
    }

    public static int GetEasyDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(Preferences.EasyDifficultyHighscore);
    }

    public static void SetMediumDifficultyHighscore(int value)
    {
        PlayerPrefs.SetInt(Preferences.MediumDifficultyHighscore, value);
    }

    public static int GetMediumDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(Preferences.MediumDifficultyHighscore);
    }

    public static void SetHardDifficultyHighscore(int value)
    {
        PlayerPrefs.SetInt(Preferences.HardDifficultyHighscore, value);
    }

    public static int GetHardDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(Preferences.HardDifficultyHighscore);
    }

    public static void SetEasyDifficultyCoinScore(int value)
    {
        PlayerPrefs.SetInt(Preferences.EasyDifficultyCoinScore, value);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(Preferences.EasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int value)
    {
        PlayerPrefs.SetInt(Preferences.MediumDifficultyCoinScore, value);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(Preferences.MediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int value)
    {
        PlayerPrefs.SetInt(Preferences.HardDifficultyCoinScore, value);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(Preferences.HardDifficultyCoinScore);
    }
    
    public static void SetMusicStatus(int value)
    {
        PlayerPrefs.SetInt(Preferences.IsMusicOn, value);
    }

    public static int GetMusicStatus()
    {
        return PlayerPrefs.GetInt(Preferences.IsMusicOn);
    }
}
