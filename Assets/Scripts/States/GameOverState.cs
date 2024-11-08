using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : MonoBehaviour
{
    public GameObject mainMenuState;
    public GameObject gamePlayState;
    public GameObject rootUI;
    private void OnEnable()
    {
        rootUI.SetActive(true);
    }
    private void OnDisable()
    {
        rootUI.SetActive(false);
    }
    public void ToMenu()
    {
        mainMenuState.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        gamePlayState.SetActive(true);
        gameObject.SetActive(false);
    }
}
