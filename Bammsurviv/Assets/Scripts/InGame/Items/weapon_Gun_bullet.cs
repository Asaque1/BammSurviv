using UnityEngine;

public class weapon_Gun_bullet : MonoBehaviour
{
    [Header("data")]
    [SerializeField] public float damage;
    public float speed = 20f;
    public float maxDistance = 30f;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // 현재 바라보고 있는 방향으로 이동 (2D용)
        transform.position += -(Vector3)transform.right * speed * Time.deltaTime;

        // 시작 위치부터 현재 위치까지의 거리를 계산
        float distanceTraveled = Vector2.Distance(startPosition, transform.position);

        // 이동한 거리가 최대 거리보다 크면 총알 제거
        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }


    public void Init(float getting_Damage, Quaternion degree)
    {
        damage = getting_Damage;
        this.gameObject.transform.rotation = degree;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            damagable.GetDamage(damage);

        }
    }


    public void onAttackEnd()
    {
        Destroy(this.gameObject);
    }

}
