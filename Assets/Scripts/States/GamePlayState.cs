using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : MonoBehaviour
{
    public GameOverState gameOverState;
    public PlayerController playerController;
    public LevelController levelController;
    public GameObject rootUI;
    private void OnEnable()
    {
        rootUI.SetActive(true);
    }
    private void OnDisable()
    {
        rootUI.SetActive(false);
    }

    public void Lose()
    {
        gameOverState.gameObject.SetActive(true);
        int score = levelController.Score;
        GameInstance.bestScore = score;
        gameObject.SetActive(false);
    }

    
}
