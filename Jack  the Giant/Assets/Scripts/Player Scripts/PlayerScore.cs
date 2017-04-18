using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    AudioClip coinClip, lifeClip;

    bool countScore;
    Vector3 previousPosition;

    CameraScript cameraScript;

    public static int coinCount, lifeCount, score;

	void Start () {
        cameraScript = Camera.main.GetComponent<CameraScript>();

        previousPosition = transform.position;
        countScore = true;
	}

	void Update () {
        CountScore();
	}

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                score++;
                previousPosition = transform.position;
                GameplayController.instance.SetScore(score);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            coinCount++;
            score += 200;
            GameplayController.instance.SetCoins(coinCount);
            GameplayController.instance.SetScore(score);
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Life")
        {
            lifeCount++;
            score += 300;
            GameplayController.instance.SetLives(lifeCount);
            GameplayController.instance.SetScore(score);
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Bounds")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            GameplayController.instance.SetLives(lifeCount);
            transform.position = new Vector3(500, 500, 0);

            lifeCount--;

            GameManager.instance.CheckGameStatus(score, coinCount, lifeCount);
        }
        else if (collision.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            GameplayController.instance.SetLives(lifeCount);
            transform.position = new Vector3(500, 500, 0);

            lifeCount--;

            GameManager.instance.CheckGameStatus(score, coinCount, lifeCount);
        }
    }
}
