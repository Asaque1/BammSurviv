using UnityEngine;

public class droppableSpawner : MonoBehaviour
{
    [System.Serializable]
    public class dropItems
    {
        public GameObject prefab;
        public int weight;
    }

    [SerializeField] public dropItems[] droppableList;
    public float spawnCTime;
    public float nowspawnCTime;

    [Header("스폰 영역")]
    [SerializeField] private Collider2D fieldCollider;

    [Header("스폰 검사")]
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float checkRadius = 0.3f;
    [SerializeField] private int maxTryCount = 50;

    [Header("플레이어 스폰 제한")]
    [SerializeField] private Transform player;
    [SerializeField] private float maxSpawnDistanceFromPlayer = 4f;

    private void Update()
    {
        if (nowspawnCTime > 0)
        {
            nowspawnCTime -= Time.deltaTime;
        }
        else
        {
            nowspawnCTime = spawnCTime;
            SpawnDroppable();
        }
    }
    public void SpawnDroppable()
    {
        if (droppableList == null || droppableList.Length == 0)
            return;

        GameObject selectedDrop = GetWeightedRandomDrop();
        if (selectedDrop == null)
            return;

        for (int i = 0; i < maxTryCount; i++)
        {
            Vector2 randomPos = GetRandomPositionInField();

            bool isBlocked = Physics2D.OverlapCircle(
                randomPos,
                checkRadius,
                obstacleLayer
            ) != null;

            if (isBlocked)
                continue;

            float distanceToPlayer = Vector2.Distance(
                randomPos,
                player.position
            );

            if (distanceToPlayer > maxSpawnDistanceFromPlayer)
                continue;

            Instantiate(
                selectedDrop,
                randomPos,
                Quaternion.identity
            );
            return;
        }
    }

    /// <summary>
    /// field collider bounds 내부에서
    /// 
    /// </summary>
    private Vector2 GetRandomPositionInField()
    {
        Bounds bounds = fieldCollider.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(x, y);
    }

    private GameObject GetWeightedRandomDrop()
    {
        int totalWeight = 0;

        // 전체 가중치 합 계산
        for (int i = 0; i < droppableList.Length; i++)
        {
            totalWeight += droppableList[i].weight;
        }

        if (totalWeight <= 0)
            return null;

        int randomValue = Random.Range(0, totalWeight);
        int currentWeight = 0;

        // 랜덤 값이 속한 아이템 찾기
        for (int i = 0; i < droppableList.Length; i++)
        {
            currentWeight += droppableList[i].weight;

            if (randomValue < currentWeight)
            {
                return droppableList[i].prefab;
            }
        }

        return null;
    }
}
