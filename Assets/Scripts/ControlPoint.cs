using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    float xRotate, yRotate = 0f;

    public Rigidbody playerBall;

    public float rotateSpeed = 5f;

    public float shotPower = 5f;

    public LineRenderer aimLine;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerBall.position;

        // Controls the player camera
        if (Input.GetMouseButton(0)) 
        {
            xRotate += Input.GetAxis("Mouse X") * rotateSpeed;
            yRotate += Input.GetAxis("Mouse Y") * rotateSpeed;
            if (yRotate < -35f) 
            {
                yRotate = -35f;
            }
            /*if (yRotate > 11f)
            {
                yRotate = 11f;
            }
            else if (yRotate < -170f) 
            {
                yRotate = -170f;
            }*/
            transform.rotation = Quaternion.Euler(yRotate, xRotate, 0f);
            aimLine.gameObject.SetActive(true);
            aimLine.SetPosition(0, transform.position);
            aimLine.SetPosition(1, transform.position + transform.forward * 7f);
        }

        // Shooting function
        if (Input.GetMouseButtonUp(0)) 
        {
            playerBall.velocity = transform.forward * shotPower;
            aimLine.gameObject.SetActive(false);
        }
    }
}
