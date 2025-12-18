using System.Collections;
using UnityEngine;

public class weapon_Axe_attack : MonoBehaviour
{
    [Header("data")]
    [SerializeField] public float damage;


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
