using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player_levels : MonoBehaviour
{
    [Header("datas")]
    [SerializeField] int nowLevel;
    [SerializeField] int nowExp;
    [SerializeField] int needExp;
    [SerializeField] public Player_StatData pData;
    [SerializeField] public Player_HP pHP;

    [Header("event")]
    [SerializeField] public UnityEvent onLevelup;

    [SerializeField] public Image guageUI;

    private void FixedUpdate()
    {
        this.gameObject.transform.localScale = new Vector3(pData.player_finalStat.Magnet, pData.player_finalStat.Magnet,1);
        if(nowExp >= needExp)
        {
            nowLevel++;
            nowExp -= needExp;
            needExp = 30 + (nowLevel * 5);
            Player_Support_anims.Instance.onLevelUp();
            onLevelup.Invoke();
        }

        guageUI.fillAmount = (float)nowExp / needExp;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exp"))
        {
            nowExp += 10;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Heal"))
        {
            pHP.nowHP += 50;
            Destroy(collision.gameObject);
            Player_Support_anims.Instance.onHeal();
        //}else if (collision.CompareTag("Box"))
        //{

        //    Destroy(collision.gameObject);
        }
    }

}
