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
        }

        // If end cubes are hit


        // If spikes are hit
    }
}
