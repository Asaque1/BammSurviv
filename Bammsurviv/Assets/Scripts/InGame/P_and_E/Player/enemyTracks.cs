using UnityEngine;

public class enemyTracks : MonoBehaviour
{
    public Transform playerTransform;
    public Quaternion attackRot;
    public Transform nearestEnemy;
    public static enemyTracks Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    void Update()
    {
        nearestEnemy = FindClosestEnemy("Enemy");
        Vector2 dir;

        if (nearestEnemy != null)
        {
            // 적을 향하는 방향
            dir = (playerTransform.position - nearestEnemy.position).normalized;

        }
        else
        {
            dir = Vector2.right; // 기본 방향
        }

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        attackRot = Quaternion.Euler(0f, 0f, angle);
    }


    Transform FindClosestEnemy(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        Transform closest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float currentDistance = Vector2.Distance(playerTransform.position, enemy.transform.position);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                closest = enemy.transform;
            }
        }

        return closest;
    }
}
