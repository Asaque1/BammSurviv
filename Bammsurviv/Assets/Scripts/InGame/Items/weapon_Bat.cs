using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class weapon_Bat : MonoBehaviour
{
    [Header("datas")]

    [SerializeField] public int level;
    [SerializeField] public float damage = 10f;
    [SerializeField] public float fDamage;
    [SerializeField] public float cTime = 4.5f;
    [SerializeField] public float fCTime;
    [SerializeField] private float now_cTime;
    [SerializeField] public bool isUlti = false;
    [SerializeField] public float knockbackForce;
    [Header("prefab and pData")]
    [SerializeField] public GameObject attack;
    [SerializeField] public GameObject attack_Ulti;
    [SerializeField] public Player_StatData pData;
    private void FixedUpdate()
    {
        if (level > 5)
        {
            isUlti = true;
        }
        else
        {
            isUlti = false;
        }

        fCTime = (cTime - (0.08f * level)) * (0.95f - pData.player_finalStat.CDown);
        fDamage = (damage * level) * (1 + pData.player_finalStat.Damage);

        if (level > 0)
            if (now_cTime > 0)
            {
                now_cTime -= Time.deltaTime;
            }
            else
            {
                now_cTime = fCTime;
                StartCoroutine(Attack());
            }
    }

    public IEnumerator Attack()
    {
        GameObject clone = null;
        Quaternion attackDirection = enemyTracks.Instance.attackRot;

        if (!isUlti)
        {
            clone = Instantiate(attack, this.gameObject.transform.position, attackDirection);
        }
        else
        {
            clone = Instantiate(attack_Ulti, this.gameObject.transform.position, attackDirection);
        }

        weapon_Bat_attack attack_data = clone.GetComponent<weapon_Bat_attack>();
        attack_data.Init(fDamage, attackDirection,knockbackForce);

        yield return new WaitForSeconds(0.25f);
    }
}
