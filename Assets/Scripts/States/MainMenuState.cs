using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : MonoBehaviour
{
    public GamePlayState gamePlayState;
    public TextMeshProUGUI scoreText;
    public Button startButton;
    public GameObject rootUI;

    public CameraController cameraController;

    private void OnEnable()
    {
        rootUI.SetActive(true);
        cameraController.MoveToMenu();
        scoreText.text = $"Best score: {GameInstance.bestScore}";
    }

    private void OnDisable()
    {
        rootUI.SetActive(false);
    }

    public void Play()
    {
        gamePlayState.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
