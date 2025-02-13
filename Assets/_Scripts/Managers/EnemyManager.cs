using System.Collections;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public GameDifficulty gameDifficulty;
    public Transform enemyContainer;
    public Transform swanieTransform;
    public GameObject[] enemyPrefabs = new GameObject[3];
    public float spawnRate = 2f;
    public float spawnOffset = 30f;
    public int spawnNumber = 3;
    private void Start() {
        if (!swanieTransform) {
            swanieTransform = GameObject.Find("Swanie").transform;
        }

        StartCoroutine(SpawnRandomSwan());
    }

    private void Update() {
        
    }

    public IEnumerator SpawnRandomSwan() {
        Vector2 spawnPosition = swanieTransform.position;
        spawnPosition.x += spawnOffset;
        spawnPosition.y = 0;
        GameObject normalSwan = Instantiate(selectRandomSwan(), spawnPosition, Quaternion.identity, enemyContainer);
        normalSwan.GetComponent<BaseEnemy>().swanieTransform = swanieTransform;
        yield return new WaitForSeconds(Random.Range(spawnRate, spawnRate * 2));
        StartCoroutine(SpawnRandomSwan());
    }

    public GameObject selectRandomSwan() {
        int result = Random.Range(0, spawnNumber);
        return enemyPrefabs[result];
    }
}