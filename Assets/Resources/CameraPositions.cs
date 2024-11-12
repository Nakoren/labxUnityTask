using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSpots",menuName = "CameraSpots")]
public class CameraPositions : ScriptableObject
{
    public Vector3 menuPosition;
    public Quaternion menuRotation;

    public Vector3 gamePlayPosition;
    public Quaternion gamePlayRotation;
}
