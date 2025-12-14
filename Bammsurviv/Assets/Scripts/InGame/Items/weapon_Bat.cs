using UnityEngine;

public class Weapon_Bat : MonoBehaviour
{
    [SerializeField] private float coolTime = 3.5f;
    [SerializeField] public int level=0;

    [SerializeField] public string wName = "야구방망이";
    [SerializeField] public float damage = 5f;
    [SerializeField] public string desc => $"매 {cTime}초마다 휘둘러 {damage} 피해를 입힙니다.";

    [SerializeField] public float cTime;
    [SerializeField] public float now_cTime;

    private void FixedUpdate()
    {
        if (now_cTime <= 0)
        {
            Attack();
            now_cTime = cTime;
        }
        else
        {
            now_cTime -= Time.deltaTime;
        }
    }

    public void Attack()
    {

    }
}