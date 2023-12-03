using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -10);
    [SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] float minPitch = -80f;
    [SerializeField] float maxPitch = 80f;

    Vector3 lastMousePosition;

    private void Awake()
    {
        target = GameObject.FindWithTag("Ball").transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    private void Update()
    {
        RotateCamera();
    }
    void LateUpdate()
    {
        FollowPlayer();
    }

    void RotateCamera()
    {
        Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
        transform.Rotate(Vector3.up, mouseDelta.x * rotationSpeed);

        float newPitch = transform.rotation.eulerAngles.x - mouseDelta.y * rotationSpeed;
        newPitch = Mathf.Clamp(newPitch, minPitch, maxPitch);

        transform.rotation = Quaternion.Euler(newPitch, transform.rotation.eulerAngles.y, 0);

        lastMousePosition = Input.mousePosition;
    }

    void FollowPlayer()
    {
        if (target == null)
            return;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
