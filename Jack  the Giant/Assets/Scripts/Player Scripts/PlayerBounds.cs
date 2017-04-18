using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

    float maxX, minX;

	void Start () {
        SetMinAndMaxX();
	}
	
	void Update () {
        Vector3 temp = transform.position;
        if (temp.x < minX)
            temp.x = minX;
        else if (temp.x > maxX)
            temp.x = maxX;

        transform.position = temp;
	}


    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x;
        minX = -bounds.x;
    }
}
