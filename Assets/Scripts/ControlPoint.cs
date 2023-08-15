using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    float xRotate, yRotate = 0f;

    public Rigidbody playerBall;

    public float rotateSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerBall.position;

        if (Input.GetMouseButton(0)) 
        {
            xRotate += Input.GetAxis("Mouse X") * rotateSpeed;
            yRotate += Input.GetAxis("Mouse Y") * rotateSpeed;
            transform.rotation = Quaternion.Euler(-yRotate, xRotate, 0f);
        }
    }
}
