using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    Rigidbody rb;
    [SerializeField] Transform position;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        MovePlayer();   
    }

    void MovePlayer()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float touchHorizontal = touch.deltaPosition.x / Screen.width;
            float touchVertical = touch.deltaPosition.y / Screen.height;

            moveHorizontal = touchHorizontal * speed;
            moveVertical = touchVertical * speed;
        }
        Vector3 direction = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(direction * speed);

    }

}
