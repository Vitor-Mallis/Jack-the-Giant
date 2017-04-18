using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    float speed = 1.0f;
    float acceleration = 0.1f;
    float maxSpeed = 3.4f;

    float easySpeed = 3.5f;
    float mediumSpeed = 4f;
    float hardSpeed = 4.5f; 

    [HideInInspector]
    public bool moveCamera = true;
	
    void Awake()
    {
        if(Preferences.GetEasyDifficulty() == 1)
        {
            maxSpeed = easySpeed;
        }
        else if (Preferences.GetMediumDifficulty() == 1)
        {
            maxSpeed = mediumSpeed;
        }
        else if (Preferences.GetHardDifficulty() == 1)
        {
            maxSpeed = hardSpeed;
        }
    }

	void Update () {
		if(moveCamera)
        {
            Vector3 temp = transform.position;
            float oldY = temp.y;
            float newY = temp.y - speed * Time.deltaTime;

            temp.y = Mathf.Clamp(temp.y, oldY, newY);

            transform.position = temp;

            speed += acceleration * Time.deltaTime;

            if (speed > maxSpeed)
                speed = maxSpeed;
        }
	}
}
