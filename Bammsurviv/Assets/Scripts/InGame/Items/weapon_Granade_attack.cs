using UnityEngine;
using UnityEngine.Rendering.Universal;

public class weapon_Granade_attack : MonoBehaviour
{
    [Header("data")]
    [SerializeField] public float damage;
    [SerializeField] public bool isUlti;
    [SerializeField] public GameObject fire;
    public void Init(float getting_Damage, bool gisUlti)
    {
        damage = getting_Damage;
        isUlti = gisUlti;
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
        if (!isUlti)
            Destroy(this.gameObject);
        else
        {
            GameObject explo;
            explo = Instantiate(fire, this.transform.position, Quaternion.identity);

            weapon_Granade_fire attack_data = explo.GetComponent<weapon_Granade_fire>();
            attack_data.Init(damage);
            Destroy(this.gameObject);

        }
    }
}