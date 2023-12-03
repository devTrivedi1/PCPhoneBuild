using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    float moveHorizontal;
    float moveVertical;
    Vector3 movement;
    [SerializeField] Transform position;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cylinder), position.position, Quaternion.identity);
        }
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float touchHorizontal = touch.deltaPosition.x / Screen.width;
            float touchVertical = touch.deltaPosition.y / Screen.height;

            moveHorizontal = touchHorizontal * speed;
            moveVertical = touchVertical * speed;
        }

        movement = GetDirection();
        Move(movement * speed);
    }

    private Vector3 GetDirection()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveHorizontal, 0, moveVertical);
        return direction;
    }

    private void Move(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }
}
