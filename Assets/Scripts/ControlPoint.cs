using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBall;
    [SerializeField] private LineRenderer aimLine;

    private float xRotate, yRotate = 0f;
    private float rotateSpeed = 5f;
    private float shotPower = 20f;
    private float shotAngle = 5f;
    private float stopVelocity = 7f;
    
    private bool isFlying = false;

    private Vector3 savedPos;

    // Update is called once per frame
    private void Update()
    {
        // Stops the ball when it's almost stopped
        if (playerBall.velocity.magnitude < stopVelocity)
        {
            Stop();
        }

        if (playerBall.position.y < -5f) 
        {
            playerBall.transform.position = savedPos;
            Stop();
            playerBall.velocity = Vector3.zero;
        }

        AimAndShoot();
    }

    private void AimAndShoot() 
    {
        transform.position = playerBall.position;

        // Controls the player camera
        if (Input.GetMouseButton(1))
        {
            xRotate += Input.GetAxis("Mouse X") * rotateSpeed;
            yRotate += Input.GetAxis("Mouse Y") * rotateSpeed;

            if (yRotate > 15f)
            {
                yRotate = 15f;
            }
            else if (yRotate < -150f)
            {
                yRotate = -150f;
            }
            transform.rotation = Quaternion.Euler(-yRotate, xRotate, 0f);

            // Aiming Line indicates direction and able to be shot
            
        }

        // Hold to ready the ball to be launched and 
        if (Input.GetMouseButton(0) && isFlying == false)
        {
            aimLine.gameObject.SetActive(true);
            aimLine.SetPosition(0, transform.position);
            aimLine.SetPosition(1, transform.position + transform.forward * 10f);
        }

        // Release to shoot
        if (Input.GetMouseButtonUp(0) && isFlying == false)
        {
            playerBall.velocity = transform.forward * shotPower + transform.up * shotAngle;
            aimLine.gameObject.SetActive(false);
            isFlying = true;
        }
    }

    // Stops the ball
    private void Stop() 
    {
        playerBall.angularVelocity = Vector3.zero;
        if (playerBall.velocity == Vector3.zero)
        {
            savedPos = playerBall.transform.position;
        }
        isFlying = false;
    }
}
