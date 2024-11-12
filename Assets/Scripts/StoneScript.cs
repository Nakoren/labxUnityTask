using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public bool isMarked = false;

    public event Action onCollisionStone;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<StoneScript>())
        {
            if (!isMarked)
            {
                onCollisionStone?.Invoke();
            }
            isMarked = true;
        }
        if (other.gameObject.tag == "Ground")
        {
            if (!isMarked)
            {
                onCollisionStone?.Invoke();
            }
            isMarked = true;
        }
    }
}
