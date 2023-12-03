using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2.0f;

    Vector3 lastMousePosition;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

        transform.Rotate(Vector3.up, mouseDelta.x * rotationSpeed);
        transform.Rotate(Vector3.left, mouseDelta.y * rotationSpeed);

        lastMousePosition = Input.mousePosition;
    }
}
