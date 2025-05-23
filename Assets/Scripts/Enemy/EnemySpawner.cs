using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab;
    public Transform player;
    public Camera mainCamera;
    public float spawnInterval = 3f;
    public int enemiesPerSpawn = 1;
    public float spawnDistanceFromCamera = 2f;

    [Header("Enemy Count Increment Settings")]
    [Tooltip("How often the number of enemies will increase")]
    public float enemyIncreaseInterval = 30f;
    [Tooltip("How many additional enemies to spawn each increment")]
    public int enemyIncreaseAmount = 1;
    [Tooltip("Maximum number of enemies that can spawn at once")]
    public int maxEnemiesPerSpawn = 10;

    private float timeSinceLastIncrease = 0f;
    private int currentEnemiesPerSpawn;

    private void Start()
    {
        currentEnemiesPerSpawn = enemiesPerSpawn;
        StartCoroutine(SpawnRoutine());
    }

    private void Update()
    {
        timeSinceLastIncrease += Time.deltaTime;
        
        if (timeSinceLastIncrease >= enemyIncreaseInterval)
        {
            timeSinceLastIncrease = 0f;
            IncreaseEnemyCount();
        }
    }

    void IncreaseEnemyCount()
    {
        currentEnemiesPerSpawn = Mathf.Min(currentEnemiesPerSpawn + enemyIncreaseAmount, maxEnemiesPerSpawn);
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < currentEnemiesPerSpawn; i++)
        {
            Vector3 spawnPos = GetRandomPositionOutsideCamera();
            GameObject enemyObj = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            IEnemy enemy = enemyObj.GetComponent<IEnemy>();
            if (enemy != null)
            {
                enemy.Initialize(player);
                enemy.OnSpawned();
            }
        }
    }

    Vector3 GetRandomPositionOutsideCamera()
    {
        // 카메라 뷰포트 밖 랜덤 위치 계산
        float side = Random.value;
        Vector3 viewportPos;
        if (side < 0.25f) // 왼쪽
            viewportPos = new Vector3(-0.1f, Random.value, 0);
        else if (side < 0.5f) // 오른쪽
            viewportPos = new Vector3(1.1f, Random.value, 0);
        else if (side < 0.75f) // 아래
            viewportPos = new Vector3(Random.value, -0.1f, 0);
        else // 위
            viewportPos = new Vector3(Random.value, 1.1f, 0);

        Vector3 worldPos = mainCamera.ViewportToWorldPoint(viewportPos);
        worldPos.z = 0;
        // 카메라 밖으로 spawnDistanceFromCamera만큼 더 밀어냄
        Vector3 camToSpawn = (worldPos - mainCamera.transform.position).normalized;
        worldPos += camToSpawn * spawnDistanceFromCamera;
        return worldPos;
    }
} 