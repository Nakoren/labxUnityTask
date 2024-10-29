using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform stick;
    private Vector3 baseRotation;
    public float maxAngle = 30;
    // Update is called once per frame

    private void Start()
    {
        baseRotation = stick.localEulerAngles;
    }
    void Update()
    {
        var angle = stick.localEulerAngles;
        if (Input.GetMouseButton(0))
        {
            angle.x =  baseRotation.y+maxAngle;
        }
        else
        {
            angle.x = baseRotation.y-maxAngle;
        }
        stick.localEulerAngles = angle;
    }
}
