using UnityEngine;

public class FindNearestEnemy : MonoBehaviour
{
    public float searchRadius = 5f;
    public LayerMask enemyLayer;

    public GameObject GetNearestEnemyInRange()
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

        return nearestEnemy;
    }
}