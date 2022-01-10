using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float lowerLimit = -10f;

    void Update()
    {
        if (transform.position.x < lowerLimit)
        {
            Destroy(gameObject);
        }
    }
}
