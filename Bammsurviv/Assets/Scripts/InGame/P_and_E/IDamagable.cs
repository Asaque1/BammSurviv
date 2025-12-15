using UnityEngine;
using UnityEngine.Events;

public interface IDamagable
{
    void GetDamage(float damage) { }
    public void Die();

}
