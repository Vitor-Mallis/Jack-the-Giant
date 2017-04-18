using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    PlayerJoystick playerJoystick;

    void Awake() {
        playerJoystick = GameObject.Find("Player").GetComponent<PlayerJoystick>();
    }

	public void OnPointerDown(PointerEventData data) {
        if(gameObject.name == "Left") {
            playerJoystick.SetMoveLeft(true);
        }
        else {
            playerJoystick.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData data) {
        playerJoystick.StopMoving();
    }
}
