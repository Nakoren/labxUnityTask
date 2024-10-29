using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindrop_script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
