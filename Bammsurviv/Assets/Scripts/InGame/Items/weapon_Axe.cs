using UnityEngine;

public class Weapon_Axe : MonoBehaviour
{
    [Header("datas")]

    [SerializeField] public int level;
    [SerializeField] public float damage = 8f;
    [SerializeField] public float fDamage;
    [SerializeField] public float cTime = 4.5f;
    [SerializeField] public float fCTime;
    [SerializeField] private float now_cTime;

    [Header("prefab and pData")]
    [SerializeField] public GameObject attack;
    [SerializeField] public Player_StatData pData;
    //[SerializeField] public

    private void FixedUpdate()
    {
        fCTime = (cTime -(0.1f*level)) * (1-pData.player_finalStat.CDown);
        fDamage = (damage * level)*(1+pData.player_finalStat.Damage);
        
        if (level > 0)
            if (now_cTime <= 0)
            {
                Attack();
                now_cTime = fCTime;
            }
            else
            {
                now_cTime -= Time.deltaTime;
            }

    }
    public GameObject GetNearestEnemy()
    {
        // 1. 태그로 모든 적 오브젝트를 찾는다
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject nearestEnemy = null;
        float shortestDistance = 6f;

        // 2. 하나씩 거리 비교
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            // 3. 가장 가까운 적 갱신
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public void Attack()
    {
        GameObject clone = Instantiate(attack,this.gameObject.transform.position,new Quaternion(0,0,0,0));
        weapon_Axe_attack attack_data = clone.GetComponent<weapon_Axe_attack>();
        attack_data.Init(damage);
    }


}