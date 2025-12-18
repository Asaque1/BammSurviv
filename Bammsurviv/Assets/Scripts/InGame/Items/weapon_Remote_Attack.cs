using UnityEngine;

public class weapon_Remote_Attack : MonoBehaviour
{
    [SerializeField] public float damage;
    [SerializeField] public GameObject target;

    public void Init(float getdamage, GameObject gettarget)
    {
        damage = getdamage;
        target = gettarget;
    }
    private void Start()
    {
        this.gameObject.transform.position = target.transform.position + new Vector3(0, 2f,0);
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
