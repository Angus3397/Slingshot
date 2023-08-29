using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    /*[SerializeField] Rigidbody player;
    private Vector3 savedPos;
    private float stopVelocity = 10f;*/

    /*private void Update()
    {
        if (player.velocity.magnitude < stopVelocity) 
        {
            savedPos = transform.position;
        }

        if (player.position.y < -1f) 
        {
            transform.position = savedPos;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        // If point cubes are hit
        if (other.gameObject.tag == "Points")
        {
            Destroy(other.gameObject);
            ScoreManager.instance.AddPoint();
        }

        // If end cubes are hit
        if (other.gameObject.tag == "End")
        {
            ScoreManager.instance.GameOverScreen();
        }

        // If spikes are hit

    }
}
