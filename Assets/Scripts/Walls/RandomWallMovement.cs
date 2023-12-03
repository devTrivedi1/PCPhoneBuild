using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class RandomWallMovement : MonoBehaviour
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float changeDirectionInterval;
    [SerializeField] float moveSpeed;
    [SerializeField] float timeSinceDirectionChange;
    bool startMovingRight;

    bool timeIsReset;

    [SerializeField] Vector3 moveDirection;
    void Start()
    {
        moveDirection = startMovingRight ? Vector3.forward : Vector3.back;
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        InvokeRepeating(nameof(DirectionChanges), changeDirectionInterval, changeDirectionInterval);
    }

    private void Update()
    {
        MoveWalls();
    }

    void FixedUpdate()
    {
        timeSinceDirectionChange += Time.deltaTime;
    }

    void DirectionChanges()
    {
        timeIsReset = true;
        moveDirection = Random.Range(0, 2) == 0 ? Vector3.forward : Vector3.back;

        Debug.Log("Time is reset" + timeSinceDirectionChange);
        timeSinceDirectionChange = 0;
        Invoke(nameof(AllowToResetTime), changeDirectionInterval);
    }

    void AllowToResetTime()
    {
        timeIsReset = false;
    }

    void MoveWalls()
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            moveDirection = -moveDirection;
        }

        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().gameHasEnded = true;
        }
    }
}