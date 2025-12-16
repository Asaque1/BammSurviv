using UnityEngine;

public class Weapon_Bat : MonoBehaviour
{
    [Header("datas")]

    [SerializeField] public float damage = 5f;
    [SerializeField] public float fDamage;
    [SerializeField] public float cTime = 3.5f;
    [SerializeField] public float fCTime;
    [SerializeField] private float now_cTime;

    [Header("prefab and pData")]
    [SerializeField] public GameObject attack;
    [SerializeField] public Player_StatData pData;
    [SerializeField] public ChooseM chooseM;

    private void FixedUpdate()
    {
        fCTime = (cTime) * (1-pData.player_finalStat.CDown);
        fDamage = (damage * chooseM.itemList[0].itemLevel)*(1+pData.player_finalStat.Damage);

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
        weapon_Bat_attack attack_data = clone.GetComponent<weapon_Bat_attack>();
        attack_data.Init(damage);
    }
}