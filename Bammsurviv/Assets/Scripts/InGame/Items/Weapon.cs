using Unity.VisualScripting;
using UnityEngine;

public interface Weapon
{
    string wName { get; set; }
    string desc { get; set; }

    float damage { get; set; }
    float cTime { get; set; }

    void Attack(IDamagable damageable);
}