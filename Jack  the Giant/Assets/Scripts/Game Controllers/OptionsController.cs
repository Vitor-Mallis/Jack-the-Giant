using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    [SerializeField]
    GameObject EasyCheckmark, MediumCheckmark, HardCheckmark;

    void Awake()
    {
        if (Preferences.GetEasyDifficulty() == 1)
            EasyCheckmark.SetActive(true);
        else if (Preferences.GetMediumDifficulty() == 1)
            MediumCheckmark.SetActive(true);
        else if (Preferences.GetHardDifficulty() == 1)
            HardCheckmark.SetActive(true);
    }

	public void EasyButton()
    {
        Preferences.SetEasyDifficulty(1);
        Preferences.SetMediumDifficulty(0);
        Preferences.SetHardDifficulty(0);
        EasyCheckmark.SetActive(true);
        MediumCheckmark.SetActive(false);
        HardCheckmark.SetActive(false);
    }

    public void MediumButton()
    {
        Preferences.SetEasyDifficulty(0);
        Preferences.SetMediumDifficulty(1);
        Preferences.SetHardDifficulty(0);
        EasyCheckmark.SetActive(false);
        MediumCheckmark.SetActive(true);
        HardCheckmark.SetActive(false);
    }

    public void HardButton()
    {
        Preferences.SetEasyDifficulty(0);
        Preferences.SetMediumDifficulty(0);
        Preferences.SetHardDifficulty(1);
        EasyCheckmark.SetActive(false);
        MediumCheckmark.SetActive(false);
        HardCheckmark.SetActive(true);
    }

    public void TitleScreen()
    {
        FaderScript.instance.LoadLevel("TitleScreen");
    }
}
