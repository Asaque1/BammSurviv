using System.Collections;
using UnityEngine;

public class weapon_Axe_attack : MonoBehaviour
{
    [Header("data")]
    [SerializeField] public float damage;

    public void Init(float getting_Damage)
    {
        damage = getting_Damage;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            if (damagable != null) damagable.GetDamage(damage);

        }
    }

    private void Start()
    {
        
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }
}
