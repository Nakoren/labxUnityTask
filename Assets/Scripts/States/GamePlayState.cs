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

    private void onLose()
    {

    }

    
}
