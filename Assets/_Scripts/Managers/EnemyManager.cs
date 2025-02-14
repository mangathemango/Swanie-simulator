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

    private SwanieMovement swanieMovement;
    private GameDifficulty.Difficulty[] difficulties;
    private GameDifficulty.Difficulty currentDifficulty;
    private int currentDifficultyIndex = 0;
    private void Start() {
        if (!swanieTransform) {
            swanieTransform = GameObject.Find("Swanie").transform;
        }
        swanieMovement = GameObject.Find("Swanie").GetComponent<SwanieMovement>();
        difficulties = gameDifficulties.difficulties;
        currentDifficulty = difficulties[startDifficulty];
        currentDifficultyIndex = startDifficulty;

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
        if (normalSwan.GetComponent<Mango>()) {
            yield return new WaitUntil(() => swanieMovement.hasMango);
            currentDifficulty = difficulties[6];
            currentDifficultyIndex = 6;
        }
        yield return new WaitForSeconds(Random.Range(spawnRate, spawnRate * 2));
        if (GameManager.Instance.gameStarted) {
            StartCoroutine(SpawnRandomSwan());
        }
    }

    public GameObject selectRandomSwan() {
        if (currentDifficulty.numberOfEnemies == 4) {
            return enemyPrefabs[3];
        }
        int result = Random.Range(0, currentDifficulty.numberOfEnemies > enemyPrefabs.Length ? enemyPrefabs.Length : currentDifficulty.numberOfEnemies);
        return enemyPrefabs[result];
    }
}