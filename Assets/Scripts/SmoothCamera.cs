using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    private Vector3 nextPosition;
    private Quaternion nextRotation;
    private bool movingStatus = false;
    private bool rotatingStatus = false;
    public void SmoothMoveTo(Vector3 newPosition, Quaternion newRotation)
    {
        nextPosition = newPosition;
        nextRotation = newRotation;
        movingStatus = true;
        rotatingStatus = true;
    }

    private void Update()
    {
        if (movingStatus)
        {
            if (Vector3.Distance(transform.position, nextPosition) > 0.1)
            {
                Debug.Log("MovingCamera");
                transform.position = Vector3.Lerp(transform.position, nextPosition, moveSpeed);
            }
            else
            {
                movingStatus = false;
            }
        }
        if (rotatingStatus)
        {
            if (Quaternion.Angle(transform.rotation, nextRotation) > 1)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, rotationSpeed);
            }
            else
            {
                rotatingStatus = false;
            }
        }
    }
}
