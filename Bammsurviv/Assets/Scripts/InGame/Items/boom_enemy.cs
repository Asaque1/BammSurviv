using UnityEngine;

public class boom_enemy : MonoBehaviour
{
    public string targetTag="Player";
    public float damage = 30;

    void Start()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            damagable.GetDamage(damage);
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
