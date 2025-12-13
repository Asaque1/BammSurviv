using UnityEngine;
using UnityEngine.Events;

public interface IDamagable
{
    void GetDamage() { }
    void Die(UnityEvent die) {
        die.Invoke();
    }
}
