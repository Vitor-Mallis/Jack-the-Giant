using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour {

    [SerializeField]
    Button musicButton;

    [SerializeField]
    Sprite[] musicIcons; 

    void Start() {
        Time.timeScale = 1f;
        CheckToPlayMusic();
    }

    void CheckToPlayMusic() {
        if(Preferences.GetMusicStatus() == 1) {
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[0];
        }
        else {
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[1];
        }
    }

    public void StartGame()
    {
        GameManager.instance.gameStarted = true;
        FaderScript.instance.LoadLevel("Gameplay");
    }

    public void Highscore()
    {
        FaderScript.instance.LoadLevel("Highscore");
    }

    public void Options()
    {
        FaderScript.instance.LoadLevel("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MusicOn()
    {
        if (Preferences.GetMusicStatus() == 1) {
            Preferences.SetMusicStatus(0);
        }
        else {
            Preferences.SetMusicStatus(1);
        }

        CheckToPlayMusic();
    }
}
