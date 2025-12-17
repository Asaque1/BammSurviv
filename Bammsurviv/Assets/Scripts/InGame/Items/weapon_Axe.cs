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

    private void FixedUpdate()
    {
        fCTime = (cTime -(0.1f*level)) * (1-pData.player_finalStat.CDown);
        fDamage = (damage * level)*(1+pData.player_finalStat.Damage);

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

    public void Attack()
    {
        GameObject clone = Instantiate(attack,this.gameObject.transform.position,new Quaternion(0,0,0,0));
        weapon_Axe_attack attack_data = clone.GetComponent<weapon_Axe_attack>();
        attack_data.Init(damage);
    }


}