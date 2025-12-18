using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class enemy
    {
        public string name;
        public int maxHp;
        public float MS;
        public int damage;
        public GameObject prefab;
        public int weight;
    }

    [Header("Enemy Data")]
    [SerializeField] public enemy[] enemyList;

    [Header("Spawn Time")]
    public float spawnCTime = 2f;
    public float nowspawnCTime;

    [Header("Spawn Area")]
    [SerializeField] private Collider2D fieldCollider;

    [Header("Spawn Check")]
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float checkRadius = 0.3f;
    [SerializeField] private int maxTryCount = 50;

    [Header("Player Distance Limit")]
    [SerializeField] private Transform player;
    [SerializeField] private float minSpawnDistanceFromPlayer = 2.5f;

    [Header("Difficulty Scaling (HP)")]
    [SerializeField] private float hpIncreaseInterval = 30f;   // 몇 초마다
    [SerializeField] private float hpMultiplierPerStep = 0.2f; // 단계당 +20%
    [SerializeField] private float maxHpMultiplier = 5f;       // 최대 배율 제한
    int step;

    private void Update()
    {    spawnCTime = 2-(step * hpMultiplierPerStep * 0.25f);
        if (nowspawnCTime > 0)
        {
            nowspawnCTime -= Time.deltaTime;
        }
        else
        {
            nowspawnCTime = spawnCTime;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        if (enemyList == null || enemyList.Length == 0)
            return;

        enemy selectedEnemy = GetWeightedRandomEnemy();
        if (selectedEnemy == null || selectedEnemy.prefab == null)
            return;

        for (int i = 0; i < maxTryCount; i++)
        {
            Vector2 randomPos = GetRandomPositionInField();

            bool isBlocked = Physics2D.OverlapCircle(
                randomPos,
                checkRadius,
                obstacleLayer
            );

            if (isBlocked)
                continue;

            float distanceToPlayer = Vector2.Distance(
                randomPos,
                player.position
            );

            if (distanceToPlayer < minSpawnDistanceFromPlayer)
                continue;

            GameObject madeEnemy = Instantiate(
                selectedEnemy.prefab,
                randomPos,
                Quaternion.identity
            );

            madeEnemy.layer = LayerMask.NameToLayer("Enemy");

            float hpMultiplier = GetCurrentHpMultiplier();
            int scaledHp = Mathf.RoundToInt(selectedEnemy.maxHp * hpMultiplier);

            Enemy enemyComponent = madeEnemy.GetComponent<Enemy>();
            enemyComponent.Init(
                scaledHp,
                selectedEnemy.damage,
                selectedEnemy.MS
            );

            return;
        }
    }

    /// <summary>
    /// field collider bounds 내부에서 랜덤 좌표 반환
    /// </summary>
    private Vector2 GetRandomPositionInField()
    {
        Bounds bounds = fieldCollider.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(x, y);
    }

    /// <summary>
    /// 가중치 기반 적 선택
    /// </summary>
    private enemy GetWeightedRandomEnemy()
    {
        int totalWeight = 0;

        for (int i = 0; i < enemyList.Length; i++)
        {
            totalWeight += enemyList[i].weight;
        }

        if (totalWeight <= 0)
            return null;

        int randomValue = Random.Range(0, totalWeight);
        int currentWeight = 0;

        for (int i = 0; i < enemyList.Length; i++)
        {
            currentWeight += enemyList[i].weight;

            if (randomValue < currentWeight)
                return enemyList[i];
        }

        return null;
    }

    /// <summary>
    /// 시간 경과에 따른 체력 배율 계산
    /// </summary>
    private float GetCurrentHpMultiplier()
    {
        float elapsedTime = Time.time;
        step = Mathf.FloorToInt(elapsedTime / hpIncreaseInterval);

        float multiplier = 1f + step * hpMultiplierPerStep;
        return Mathf.Min(multiplier, maxHpMultiplier);
    }
}
