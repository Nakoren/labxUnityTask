using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Boulder_spawner bSpawner;
    [SerializeField]
    private Cloud_controller cController;
    [SerializeField]
    private Tool_swapper tSwapper;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            bSpawner.Spawn();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            cController.ChangeMoveTarget();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            tSwapper.Swap();
        }
    }
}
