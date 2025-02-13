using System.Collections;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public GameDifficulty gameDifficulties;
    public Transform enemyContainer;
    public Transform swanieTransform;
    public GameObject[] enemyPrefabs = new GameObject[3];
    public float spawnRate = 2f;
    public float spawnOffset = 30f;
    public int startDifficulty = 0;

    private GameDifficulty.Difficulty[] difficulties;
    private GameDifficulty.Difficulty currentDifficulty;
    private int currentDifficultyIndex = 0;
    private void Start() {
        if (!swanieTransform) {
            swanieTransform = GameObject.Find("Swanie").transform;
        }
        difficulties = gameDifficulties.difficulties;
        currentDifficulty = difficulties[startDifficulty];
        currentDifficultyIndex = startDifficulty;
        StartCoroutine(SpawnRandomSwan());
        Debug.Log(currentDifficultyIndex);
    }

    private void Update() {
        if (difficulties[currentDifficultyIndex + 1].scoresToTriggerDifficulty <= GameManager.Instance.score) {
            currentDifficultyIndex++;
            currentDifficulty = difficulties[currentDifficultyIndex];
            Debug.Log("Difficulty increased to " + currentDifficultyIndex);
        }
    }

    public IEnumerator SpawnRandomSwan() {
        Vector2 spawnPosition = swanieTransform.position;
        spawnPosition.x += spawnOffset;
        spawnPosition.y = 0;

        GameObject normalSwan = Instantiate(selectRandomSwan(), spawnPosition, Quaternion.identity, enemyContainer);
        normalSwan.GetComponent<BaseEnemy>().swanieTransform = swanieTransform;
        normalSwan.GetComponent<BaseEnemy>().speed *= currentDifficulty.enemySpeedMultiplier;

        spawnRate = currentDifficulty.enemySpawnRate;
        yield return new WaitForSeconds(Random.Range(spawnRate, spawnRate * 2));
        StartCoroutine(SpawnRandomSwan());
    }

    public GameObject selectRandomSwan() {
        int result = Random.Range(0, currentDifficulty.numberOfEnemies > enemyPrefabs.Length ? enemyPrefabs.Length : currentDifficulty.numberOfEnemies);
        return enemyPrefabs[result];
    }
}