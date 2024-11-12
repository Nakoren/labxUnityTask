using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayState : MonoBehaviour
{
    public GameOverState gameOverState;
    public PlayerController playerController;
    public LevelController levelController;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public GameObject rootUI;

    private void OnEnable()
    {
        levelController.gameObject.SetActive(true);
        playerController.gameObject.SetActive(true);
        rootUI.SetActive(true);

        scoreText.text = $"Score: 0";
        lifeText.text = $"HP: {levelController.max_hp}";
        levelController.onLose += Lose;
        levelController.onLifeChange += LifeChange;
        levelController.onScoreInc += ScoreInc;
    }
    private void OnDisable()
    {
        levelController.gameObject.SetActive(false);
        playerController.gameObject.SetActive(false);
        if (levelController != null)
        {
            levelController.onLose -= Lose;
            levelController.onScoreInc -= ScoreInc;
            levelController.onLifeChange -= LifeChange;
        }
        rootUI.SetActive(false);
    }

    private void Lose()
    {
        gameOverState.gameObject.SetActive(true); 
        gameObject.SetActive(false);
    }

    private void ScoreInc(int newScore)
    {
        Debug.Log($"Updating score to {newScore}");
        scoreText.text = $"Score: {newScore.ToString()}";
    }

    private void LifeChange(int newLife)
    {
        Debug.Log($"Updating HP to {newLife}");
        lifeText.text = $"HP: {newLife.ToString()}";
    }

}
