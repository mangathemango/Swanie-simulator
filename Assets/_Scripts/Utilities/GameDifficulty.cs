using UnityEngine;

[CreateAssetMenu(fileName = "GameDifficulty", menuName = "GameDifficulty", order = 0)]
public class GameDifficulty: ScriptableObject {
    [System.Serializable]
    public struct Difficulty {
        public float enemySpeedMultiplier;
        [Range(1,3)]
        public int numberOfEnemies;
        public float enemySpawnRate;
        public int scoresToTriggerDifficulty;
    }
    [SerializeField] public Difficulty[] difficulties = new Difficulty[10];
}