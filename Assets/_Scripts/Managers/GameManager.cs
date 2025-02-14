using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: Singleton<GameManager> {
    public int score = 0;
    public bool gameStarted = false;
    [SerializeField] private SwanieMovement swanie;
    private void Start() {
        score = 0;
        UiManager.Instance.SetMainMenu();
    }

    public void StartGame() {
        gameStarted = true;
        swanie.StartRunning();
        score = 0;
        StartCoroutine(EnemyManager.Instance.SpawnRandomSwan());
        UiManager.Instance.SetGameUI();
    }

    public void EndGame() {
        gameStarted = false;
        UiManager.Instance.SetGameOver();
    }

    public void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}