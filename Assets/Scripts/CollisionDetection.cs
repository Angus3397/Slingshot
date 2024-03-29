using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
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
