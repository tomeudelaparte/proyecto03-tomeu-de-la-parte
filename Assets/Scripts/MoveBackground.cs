using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed = 5f;
    private float repeateWidth;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        repeateWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < startPosition.x - repeateWidth)
        {
            transform.position = startPosition;
        }
    }
}
