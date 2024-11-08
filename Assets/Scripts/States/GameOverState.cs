using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : MonoBehaviour
{

    public GameObject rootUI;
    private void OnEnable()
    {
        rootUI.SetActive(true);
    }
    private void OnDisable()
    {
        rootUI.SetActive(false);
    }
}
