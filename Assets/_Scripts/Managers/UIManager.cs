using UnityEngine;
using TMPro;

public class UiManager: Singleton<UiManager> {
    [SerializeField] private TextMeshProUGUI scoreText;
    public void UpdateScore(int score) {
        scoreText.text = score.ToString();
    }
    private void Start() {
        UpdateScore(0);
    }
    private void Update() {
        UpdateScore(GameManager.Instance.score);   
    }
}