using System;
using UnityEngine;

public class GameManager: Singleton<GameManager> {
    public int score = 0;
    private void Start() {
        score = 0;
        UiManager.Instance.SetMainMenu();
    }

    public void StartGame() {
        score = 0;
        StartCoroutine(EnemyManager.Instance.SpawnRandomSwan());
        UiManager.Instance.SetGameUI();
    }
}