using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] GameObject[] enemyPrefabs;

    [Header("Difficulty Scaling")]
    public float difficultyInterval = 30f; // 난이도 증가 주기(초)
    public int spawnIncreaseAmount = 1;    // 증가량
    public int maxSpawnCount = 20;          // 최대 스폰 수

    public float spawnInterval = 1.5f;
    public int spawnCount = 5;

    public float minSpawnDistance = 8f;
    public float maxSpawnDistance = 15f;
    public int maxTryCount = 10;

    private Transform player;
    private float timer;
    private float difficultyTimer;

    void Update()
    {
        timer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        // 스폰
        if (timer >= spawnInterval)
        {
            SpawnEnemies();
            timer = 0f;
        }

        if (difficultyTimer >= difficultyInterval)
        {
            IncreaseSpawnCount();
            difficultyTimer = 0f;
        }
    }
    void IncreaseSpawnCount()
    {
        spawnCount += spawnIncreaseAmount;

        if (spawnCount > maxSpawnCount)
            spawnCount = maxSpawnCount;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 spawnPos;

            if (TryGetSpawnPosition(out spawnPos))
            {
                int index = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);
            }
        }
    }

    bool TryGetSpawnPosition(out Vector2 result)
    {
        for (int i = 0; i < maxTryCount; i++)
        {
            Vector2 randomDir = Random.insideUnitCircle.normalized;

            float distance = Random.Range(minSpawnDistance, maxSpawnDistance);

            Vector3 candidatePos =
                player.position + new Vector3(randomDir.x, 0f, randomDir.y) * distance;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(candidatePos, out hit, 2f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }
}
