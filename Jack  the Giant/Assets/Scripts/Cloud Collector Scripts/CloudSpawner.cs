using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject[] collectibles;

    private GameObject player;
    private float distanceBetweenClouds = 3f;
    private float lastCloudPositionY;
    private int controlX;
    private float minX;
    private float maxX;
    
	void Awake () {
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");
        PositionThePlayer();

        for(int i = 0; i < collectibles.Length; i++)
        {
            collectibles[i].gameObject.SetActive(false);
        }
	}

	void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void Shuffle(GameObject[] arrayToShuffle)
    {
        for(int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    void CreateClouds()
    {
        Shuffle(clouds);

        float positionY = 0f;
        controlX = 0;

        for(int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;

            switch (controlX)
            {
                case 0:
                    temp.x = Random.Range(0.0f, maxX);
                    controlX = 1;
                    break;
                case 1:
                    temp.x = Random.Range(0.0f, minX);
                    controlX = 2;
                    break;
                case 2:
                    temp.x = Random.Range(1.0f, maxX);
                    controlX = 3;
                    break;
                case 3:
                    temp.x = Random.Range(-1.0f, minX);
                    controlX = 0;
                    break;
                default:
                    break;
            }

            temp.y = positionY;
            lastCloudPositionY = positionY;
            positionY -= distanceBetweenClouds;
            
            clouds[i].transform.position = temp;
        }
    }

    void PositionThePlayer()
    {
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");
        GameObject[] darkCloudsInGame = GameObject.FindGameObjectsWithTag("Deadly");

        for(int i = 0; i < darkCloudsInGame.Length; i++)
        {
            Vector3 temp = darkCloudsInGame[i].transform.position;
            if (temp.y == 0.0f)
            {
                darkCloudsInGame[i].transform.position = cloudsInGame[0].transform.position;
                cloudsInGame[0].transform.position = temp;
            }
        }

        Vector3 tempPos = cloudsInGame[0].transform.position;

        for(int i = 1; i < cloudsInGame.Length; i++)
        {
            if (tempPos.y < cloudsInGame[i].transform.position.y)
                tempPos = cloudsInGame[i].transform.position;
        }

        tempPos.y += 0.8f;
        player.transform.position = tempPos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Cloud" || collision.tag == "Deadly")
        {
            if (collision.gameObject.transform.position.y <= lastCloudPositionY)
            {
                Shuffle(clouds);
                Shuffle(collectibles);

                Vector3 temp = collision.gameObject.transform.position;

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        switch (controlX)
                        {
                            case 0:
                                temp.x = Random.Range(0.0f, maxX);
                                controlX = 1;
                                break;
                            case 1:
                                temp.x = Random.Range(0.0f, minX);
                                controlX = 2;
                                break;
                            case 2:
                                temp.x = Random.Range(1.0f, maxX);
                                controlX = 3;
                                break;
                            case 3:
                                temp.x = Random.Range(-1.0f, minX);
                                controlX = 0;
                                break;
                            default:
                                break;
                        }

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectibles.Length);

                        if (clouds[i].tag != "Deadly") {
                            if (!collectibles[random].gameObject.activeInHierarchy)
                            {
                                Vector3 tempPos = clouds[i].transform.position;
                                tempPos.y += 0.7f;

                                if (collectibles[random].tag == "Life")
                                {
                                    if (PlayerScore.lifeCount < 2)
                                    {
                                        collectibles[random].transform.position = tempPos;
                                        collectibles[random].SetActive(true);
                                    }
                                }
                                else
                                {
                                    collectibles[random].transform.position = tempPos;
                                    collectibles[random].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
