using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour{
    public float camSpeed = 80f;
    public float camTouchSpeed = 3f;
    Vector3 camPos; 

    // Update is called once per frame
    void Update(){
        camPos = transform.position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            transform.Translate( // If touch dragged, tranlate camera with vector
                -touchDeltaPosition.x * camTouchSpeed * Time.deltaTime,
                -touchDeltaPosition.y * camTouchSpeed * Time.deltaTime,
                0
            );

            camPos = transform.position;
        }

        if (Input.GetKey("w") && !(transform.position.z > 35)){
            camPos.z += camSpeed * Time.deltaTime;
        }

        if(Input.GetKey("s") && !(transform.position.z < -5)){
            camPos.z -= camSpeed * Time.deltaTime;
        }

        if(Input.GetKey("a") && !(transform.position.x < 0)){
            camPos.x -= camSpeed * Time.deltaTime;
        }

        if(Input.GetKey("d") && !(transform.position.x > 50)){
            camPos.x += camSpeed * Time.deltaTime;
        }

        transform.position = camPos;
    }
}
