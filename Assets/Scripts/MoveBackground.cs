using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveLeft))]
public class MoveBackground : MonoBehaviour
{
    private float repeateWidth;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        repeateWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < startPosition.x - repeateWidth)
        {
            transform.position = startPosition;
        }
    }
}
