using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class weapon_Gun : MonoBehaviour
{
    [Header("datas")]

    [SerializeField] public int level;
    [SerializeField] public float damage = 20f;
    [SerializeField] public float fDamage;
    [SerializeField] public float cTime = 4.5f;
    [SerializeField] public float fCTime;
    [SerializeField] private float now_cTime;
    [SerializeField] public bool isUlti = false;
    [SerializeField] public int AAmount;
    [Header("prefab and pData")]
    [SerializeField] public GameObject attack;
    [SerializeField] public GameObject attack_Ulti;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Player_StatData pData;
    //[SerializeField] public

    private void FixedUpdate()
    {
        if (level > 5)
        {
            isUlti = true;
            AAmount = pData.player_finalStat.AAmount + 3;
        }
        else
        {
            isUlti = false;
        }

        fCTime = (cTime - (0.1f * level)) * (1 - pData.player_finalStat.CDown);
        fDamage = (damage * level) * (1 + pData.player_finalStat.Damage);

        if (level > 0)
            if (now_cTime > 0)
            {
                now_cTime -= Time.deltaTime;
            }
            else
            {
                now_cTime = fCTime;
                for (int i = 0; i <= AAmount + 1; i++)
                {
                    StartCoroutine(Attack());
                }
            }
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.4f);
        GameObject clone = null;
        Quaternion attackDirection = enemyTracks.Instance.attackRot;

        clone = Instantiate(bullet, this.gameObject.transform.position, attackDirection);

        if (!isUlti)
        {
            Instantiate(attack, this.gameObject.transform.position, attackDirection);
        }
        else
        {
            Instantiate(attack_Ulti, this.gameObject.transform.position, attackDirection);
        }

        weapon_Gun_bullet attack_data = clone.GetComponent<weapon_Gun_bullet>();
        attack_data.Init(fDamage, attackDirection);


    }



}
