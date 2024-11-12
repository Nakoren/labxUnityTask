using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public SmoothCamera smoothCamera;
    public CameraPositions cameraPositions;
    
    public void MoveToMenu()
    {
        moveCamera(cameraPositions.menuPosition, cameraPositions.menuRotation);
    }

    public void MoveToGamePlay()
    {
        moveCamera(cameraPositions.gamePlayPosition, cameraPositions.gamePlayRotation);
    }

    public void moveCamera(Vector3 newPosition, Quaternion newRotation)
    {
        smoothCamera.SmoothMoveTo(newPosition, newRotation);
    }
}
