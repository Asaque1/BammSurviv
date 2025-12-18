using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class weapon_Granade_fire : MonoBehaviour
{
    [SerializeField] public float damage;
    private List<GameObject> enemys = new List<GameObject>();
    [SerializeField] public float dur;
    [SerializeField] public Player_StatData pData;
    [SerializeField] public float dTime;
    public void Init(float getDamage)
    {
        damage = getDamage;
        dur = pData.player_finalStat.Duration;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemys.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemys.Remove(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dTime >= 0)
        {
            dTime -= Time.deltaTime;
        }
        else
        {
            onAttackEnd();
        }

            foreach (GameObject enemy in enemys)
            {
                if (enemy != null)
                {
                    // 적 공격 로직
                    IDamagable damagable = enemy.GetComponent<IDamagable>();
                    if (damagable != null)
                    {
                        damagable.GetDamage(damage / 10);
                    }
                }
                else
                {
                    // 리스트에서 제거
                    enemys.Remove(enemy);
                }
            }
    }

    void onAttackEnd()
    {
        Destroy(this.gameObject);
    }
}
