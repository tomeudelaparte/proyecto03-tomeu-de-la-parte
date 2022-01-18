using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVelocity : MonoBehaviour
{
    float velocity = 1f;

    void Start()
    {
        InvokeRepeating("increaseVelocity", 1f, 1f);
    }

    private void increaseVelocity()
    {
        if (velocity <= 2)
        {
            velocity += 0.01f;

            Time.timeScale = velocity;
        }
    }
}
