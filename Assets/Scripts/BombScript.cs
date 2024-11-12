using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    public event Action onCollisionBomb;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<StickScript>())
        {
            onCollisionBomb?.Invoke();
            onCollisionBomb = null;
        }
        Destroy(this.gameObject);
    }
}
