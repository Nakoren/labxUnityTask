using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverState : MonoBehaviour
{
    public GameObject mainMenuState;
    public GameObject gamePlayState;
    public TextMeshProUGUI scoreText;
    public GameObject rootUI;
    public GameObject recordUI;

    public CameraController cameraController;
    private void OnEnable()
    {
        rootUI.SetActive(true);
        scoreText.text= $"Score:\n{GameInstance.lastScore.ToString()}";
        recordUI.SetActive(GameInstance.NewBest);
    }
    private void OnDisable()
    {
        recordUI.SetActive(false);
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
