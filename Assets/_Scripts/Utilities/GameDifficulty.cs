using UnityEngine;

[CreateAssetMenu(fileName = "GameDifficulty", menuName = "GameDifficulty", order = 0)]
public class GameDifficulty: ScriptableObject {
    [System.Serializable]
    public struct Difficulty {
        public float enemySpeedMultiplier;
        public int numberOfEnemies;
        public float enemySpawnRate;
        public int scoresToTriggerDifficulty;

        public Difficulty(float speedMultiplier, int enemies, float spawnRate, int scores) {
            enemySpeedMultiplier = speedMultiplier;
            numberOfEnemies = enemies;
            enemySpawnRate = spawnRate;
            scoresToTriggerDifficulty = scores;
        }
    }
    [SerializeField] public Difficulty[] difficulties = new Difficulty[10];
    public GameDifficulty() {
        for (int i = 0; i < difficulties.Length; i++) {
            difficulties[i] = new Difficulty(1.0f + i * 0.1f, 10 + i * 5, 1.0f - i * 0.05f, 100 * (i + 1));
        }
    }
}