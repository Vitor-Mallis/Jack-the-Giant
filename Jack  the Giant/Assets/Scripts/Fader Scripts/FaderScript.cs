using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderScript : MonoBehaviour {

    public static FaderScript instance;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    Animator animator;

    void Awake() {
        CreateSingleton();
    }

    void CreateSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string level) {
        StartCoroutine(FadeInOut(level));
    }
    
    IEnumerator FadeInOut(string level) {
        panel.SetActive(true);
        animator.Play("FadeOut");
        yield return MyCoroutine.WaitForRealSeconds(1f);
        SceneManager.LoadScene(level);
        animator.Play("FadeIn");
        yield return MyCoroutine.WaitForRealSeconds(.7f);
        panel.SetActive(false);
    }
}
