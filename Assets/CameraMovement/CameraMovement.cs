using System;
using UnityEngine;
// using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour{
    public float camSpeed = 70f;
    public float camBorderThickness = 10f;
    Vector3 camPos;
    Vector2 touchPos;
    Vector2 moveTouchPos;

    // Update is called once per frame
    void Update(){
        camPos = transform.position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            
            transform.Translate(
                -touchDeltaPosition.x * camSpeed * Time.deltaTime,
                -touchDeltaPosition.y * camSpeed * Time.deltaTime,
                0
            );

            camPos = transform.position;
        }

        if (Input.GetKey("w")){
            camPos.y += camSpeed * Time.deltaTime;
        }

        if(Input.GetKey("s")){
            camPos.y -= camSpeed * Time.deltaTime;
        }

        if(Input.GetKey("a")){
            camPos.x -= camSpeed * Time.deltaTime;
        }

        if(Input.GetKey("d")){
            camPos.x += camSpeed * Time.deltaTime;
        }

        transform.position = camPos;
    }

}
