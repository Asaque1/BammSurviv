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

    [Header("event")]
    [SerializeField] public UnityEvent onLevelup;

    [SerializeField] public Image guageUI;

    private void FixedUpdate()
    {
        this.gameObject.transform.localScale = new Vector3(pData.player_finalStat.Magnet, pData.player_finalStat.Magnet,1);
        if(nowExp >= needExp)
        {
            nowLevel++;
            nowExp = 0;
            needExp = 100 + (nowLevel * 15);
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
    }

}
