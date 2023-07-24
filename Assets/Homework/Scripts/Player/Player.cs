using Atomic;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    public AtomicVariable<int> HitPoints;
    public AtomicEvent<int> OnTakeDamage;
    public AtomicEvent OnDeath;

    public void Init()
    {
        OnTakeDamage += damage =>
        {
            HitPoints.Value -= damage;
        };
        
        HitPoints.OnChanged += hp =>
        {
            if (hp <= 0)
            {
                OnDeath?.Invoke();
            }
        };
        OnDeath += () => Debug.Log("Death");
    }
}
