using UnityEngine;

public class enemyTracks : MonoBehaviour
{
    public float searchRadius = 5f;
    public LayerMask enemyLayer;
    public static enemyTracks Instance { get; private set; }

    void Awake()
    {
        // 이미 인스턴스가 있는데, 내가 그게 아니라면
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 내가 유일한 인스턴스가 됨
        Instance = this;
    }
    public Vector3 GetNearestEnemyInRange()
    {
        // 1. 반경 안의 콜라이더만 수집
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            searchRadius,
            enemyLayer
        );

        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        // 2. 수집된 적 중 가장 가까운 적 찾기
        foreach (Collider2D hit in hits)
        {
            float distance = Vector2.Distance(
                transform.position,
                hit.transform.position
            );

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = hit.gameObject;
            }
        }

        Vector3 direction = (nearestEnemy.gameObject.transform.position - this.gameObject.transform.position).normalized;
        return direction;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }

}