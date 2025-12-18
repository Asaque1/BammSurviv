using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class weapon_Granade : MonoBehaviour
{

    [Header("datas")]

    [SerializeField] public int level;
    [SerializeField] public float damage = 20f;
    [SerializeField] public float fDamage;
    [SerializeField] public float cTime = 4.5f;
    [SerializeField] public float fCTime;
    [SerializeField] private float now_cTime;
    [SerializeField] public bool isUlti = false;
    [Header("prefab and pData")]
    [SerializeField] public GameObject attack;
    [SerializeField] public Player_StatData pData;
    //[SerializeField] public

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
                StartCoroutine(Attack());
            }
    }

    public IEnumerator Attack()
    {
        GameObject clone = null;
        clone = Instantiate(attack, this.gameObject.transform.position, Quaternion.identity);
        weapon_Granade_ball attack_data = clone.GetComponent<weapon_Granade_ball>();
        attack_data.Init(fDamage, isUlti );

        yield return new WaitForSeconds(0.4f);
    }
}
