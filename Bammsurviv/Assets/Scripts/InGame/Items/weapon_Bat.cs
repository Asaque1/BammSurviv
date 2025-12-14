using UnityEngine;

public class Weapon_Bat : MonoBehaviour, Weapon
{
    private float coolTime = 3.5f;

    public string wName = "야구방망이";
    public float damage = 5f;
    public string desc => $"매 {cTime}초마다 휘둘러 {damage} 피해를 입힙니다.";

    public float cTime
    {
        get { return coolTime; }
        set
        {
            if (value < 0.2f)
                coolTime = 0.2f;
            else
                coolTime = value;
        }
    }

    public void Attack(IDamagable damageable)
    {
        damageable.GetDamage(damage);
    }
}