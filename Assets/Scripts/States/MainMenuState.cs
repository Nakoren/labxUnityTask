using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : MonoBehaviour
{
    GamePlayState gamePlayState;
    TextMeshProUGUI scoreText;
    Button startButton;

    private void OnEnable()
    {
        scoreText.text = $"Best score: {GameInstance.bestScore}";
    }

    private void OnDisable()
    {
        
    }

    public void Play()
    {

    }
}
