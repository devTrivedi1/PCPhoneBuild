using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InstantiateObjects : MonoBehaviour
{
    [SerializeField] Transform position;
    [SerializeField] GameObject cube;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(cube, position.position, Quaternion.identity);
        }
    }
}
