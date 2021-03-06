﻿using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;

    [SerializeField]
    private float _speed = 1.0f;

    private bool movingToB;

    void FixedUpdate()
    {
        if (transform.position == _targetA.position)
        {
            movingToB = true;
        }
        else if (transform.position == _targetB.position)
        {
            movingToB = false;
        }

        if (movingToB)
        {
            MoveTo(_targetB.position);
        }
        else
        {
            MoveTo(_targetA.position);
        }

    }

    private void MoveTo(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
