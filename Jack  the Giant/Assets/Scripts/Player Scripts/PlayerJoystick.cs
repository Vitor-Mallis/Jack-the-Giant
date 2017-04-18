using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour {

    public float speed = 6f;
    public float maxVelocity = 4f;

    Rigidbody2D myBody;
    Animator myAnim;

    
     bool moveLeft, moveRight;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    public void SetMoveLeft(bool moveLeft) {
        this.moveLeft = moveLeft;
        moveRight = !moveLeft;
    }

    public void StopMoving() {
        moveLeft = moveRight = false;
        myAnim.SetBool("Walk", false);
    }

    void FixedUpdate() {
        if (moveLeft)
            MoveLeft();
        if (moveRight)
            MoveRight();
    }

    void MoveLeft() {
        float xForce = 0f;
        float velocity = Mathf.Abs(myBody.velocity.x);

        if (velocity < maxVelocity)
            xForce = -speed;

        myAnim.SetBool("Walk", true);
        Vector3 temp = transform.localScale;
        temp.x = -1.3f;
        transform.localScale = temp;

        myBody.AddForce(new Vector2(xForce, 0));
    }

    void MoveRight() {
        float xForce = 0f;
        float velocity = Mathf.Abs(myBody.velocity.x);

        if (velocity < maxVelocity)
            xForce = speed;

        myAnim.SetBool("Walk", true);
        Vector3 temp = transform.localScale;
        temp.x = 1.3f;
        transform.localScale = temp;

        myBody.AddForce(new Vector2(xForce, 0));
    }
}
