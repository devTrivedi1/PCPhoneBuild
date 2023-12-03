using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    bool hasEntered;
    [SerializeField] GameObject doorWay;
    void Update()
    {
        if (hasEntered)
        {
            Destroy(doorWay);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hasEntered = true;
        }
    }
}
