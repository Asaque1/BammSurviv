using System.Collections;
using UnityEngine;

public class weapon_Axe_attack : MonoBehaviour
{
    [Header("data")]
    [SerializeField] public float damage;
    [SerializeField] public Vector3 degreee;

    public void Init(float getting_Damage, Vector3 degree)
    {
        damage = getting_Damage;
        degreee = degree;
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
        this.transform.rotation = Quaternion.Euler(degreee);
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }
}
