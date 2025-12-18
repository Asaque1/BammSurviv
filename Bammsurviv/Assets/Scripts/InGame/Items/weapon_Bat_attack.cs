using System.Collections;
using UnityEngine;
using static EnemySpawner;

public class weapon_Bat_attack : MonoBehaviour
{
    [Header("data")]
    [SerializeField] public float damage;
    [SerializeField] public float knockbackForce;

    public void Init(float getting_Damage, Quaternion degree,float getknockbackforce)
    {
        damage = getting_Damage;
        this.gameObject.transform.rotation = degree;
        knockbackForce = getknockbackforce;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();

            // 넉백 추가
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - this.transform.position).normalized;
                StartCoroutine(Knockback(enemyRb, knockbackDirection,knockbackForce,0.4f));
            }

            damagable.GetDamage(damage);
        }
    }

    IEnumerator Knockback(Rigidbody2D target, Vector2 dir, float knockbackForce, float knockbackDuration)
    {
        if (target == null) yield break;
        // 넉백 지속 시간 동안 대기
        yield return new WaitForSeconds(knockbackDuration);


    }



    public void onAttackEnd()
    {
        Destroy(this.gameObject);
    }
}
