using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 6f;
    public float maxVelocity = 4f;

    Rigidbody2D myBody;
    Animator myAnim;

    void Awake () {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Start () {
		
	}
	
	void FixedUpdate () {
        PlayerMoveKeyboard();
	}

    void PlayerMoveKeyboard()
    {
        float xForce = 0f;
        float velocity = Mathf.Abs(myBody.velocity.x);
        float input = Input.GetAxisRaw("Horizontal");

        if(input > 0)
        {
            if(velocity < maxVelocity)
                xForce = speed;

            myAnim.SetBool("Walk", true);
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;
        }
        else if(input < 0)
        {
            if(velocity < maxVelocity)
                xForce = -speed;

            myAnim.SetBool("Walk", true);
            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;
        }
        else
        {
            myAnim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(xForce, 0));
    }
}
