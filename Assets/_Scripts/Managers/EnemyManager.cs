using System.Collections;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public Transform enemyContainer;
    public Transform swanieTransform;
    public GameObject normalSwanPrefab;
    public GameObject deformedSwanPrefab;
    public GameObject cloudSwanPrefab;
    public float spawnRate = 2f;
    public float spawnOffset = 30f;
    private void Start() {
        if (!swanieTransform) {
            swanieTransform = GameObject.Find("Swanie").transform;
        }
        Vector2 spawnPosition = swanieTransform.position;
        spawnPosition.x += spawnOffset;
        StartCoroutine(SpawnRandomSwan());
    }

    private void Update() {
        
    }

    public IEnumerator SpawnNormalSwan() {
        Vector2 spawnPosition = swanieTransform.position;
        spawnPosition.x += spawnOffset;
        spawnPosition.y = 0;
        GameObject normalSwan = Instantiate(normalSwanPrefab, spawnPosition, Quaternion.identity, enemyContainer);
        normalSwan.GetComponent<BaseEnemy>().swanieTransform = swanieTransform;
        yield return new WaitForSeconds(Random.Range(spawnRate, spawnRate * 2));
        StartCoroutine(SpawnNormalSwan());
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
        int result = Random.Range(0, 3);
        switch (result) {
            case 0:
                return normalSwanPrefab;
            case 1:
                return deformedSwanPrefab;
            case 2:
                return cloudSwanPrefab;
            default:
                return normalSwanPrefab;
        }
    }
}