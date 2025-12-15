using UnityEngine;

public class weapon_Bat_attack : MonoBehaviour
{
    [Header("data")]
    [SerializeField] public float damage;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            if (damagable != null) damagable.GetDamage(damage);

        }
    }
}
