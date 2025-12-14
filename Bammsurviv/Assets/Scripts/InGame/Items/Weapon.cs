using Unity.VisualScripting;
using UnityEngine;

public interface Weapon
{
    void Attack(IDamagable damageable);
}