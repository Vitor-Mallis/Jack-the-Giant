using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.name == "Cloud Collector") {
			gameObject.SetActive (false);
		}
    }
}
