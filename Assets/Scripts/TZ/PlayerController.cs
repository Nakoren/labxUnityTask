using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField]
        private Boulder_spawner bSpawner;
        [SerializeField]

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                bSpawner.Spawn();
            }
        }
    }
}
