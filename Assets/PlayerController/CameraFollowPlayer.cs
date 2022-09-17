using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    void Start()
    {
        cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = PlayerTransform.position +  cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }
}
