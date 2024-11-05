using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public StickScript stick;
    public float maxAngle = 30;
    public float speed = 1f * 200;

    public void UpdateDirection(bool isMouseHeld)
    {
        if (isMouseHeld)
        {
            stick.Up();
        }
        else
        {
            stick.Down();
        }
    }
}
