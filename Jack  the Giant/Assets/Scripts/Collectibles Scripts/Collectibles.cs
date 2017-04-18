using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    void OnEnable()
    {
        Invoke("DestroyCollectible", 10f);
    }

    void DestroyCollectible()
    {
        gameObject.SetActive(false);
    }
}
