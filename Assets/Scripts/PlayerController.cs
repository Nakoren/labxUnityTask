using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    StickController stickController;
    // Update is called once per frame

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void FixedUpdate()
    {
        stickController.UpdateDirection(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0));
    }

    public void PointerUp()
    {
        stickController.UpdateDirection(false);
    }
    public void PointerDown()
    {
        stickController.UpdateDirection(true);
    }

}
