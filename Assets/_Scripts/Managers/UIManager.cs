using UnityEngine;
using TMPro;

public class UiManager: Singleton<UiManager> {
    [SerializeField] public Canvas gameUI;
    [SerializeField] public Canvas mainMenu;
    [SerializeField] public Canvas gameOver;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI mangoText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    public void UpdateScore(int score) {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateMangoStatus(bool hasMango, bool readyToShoot) {
        if (!hasMango) {
            mangoText.text = "";
            return;
        }
        mangoText.text = readyToShoot ? "Mango: Ready\nPress [Z] to shoot" : "Mango: Not ready";
    }
    public void SetMainMenu() {
        gameUI.enabled = false;
        mainMenu.enabled = true;
        gameOver.enabled = false;
    }
    public void SetGameUI() {
        gameUI.enabled = true;
        mainMenu.enabled = false;
        gameOver.enabled = false;
    }

    public void SetGameOver() {
        gameUI.enabled = false;
        mainMenu.enabled = false;
        gameOver.enabled = true;
        gameOverScoreText.text = "Score: " + GameManager.Instance.score.ToString();
    }

    private void Start() {
        UpdateScore(0);
        UpdateMangoStatus(false, false);
    }
    private void Update() {
        UpdateScore(GameManager.Instance.score);   
    }
}