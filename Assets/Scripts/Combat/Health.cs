using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int Value { get; private set; }
    [field: SerializeField] public int MaxValue { get; private set; }

    public event Action<int> Changed;
    public event Action Died;

    private void Awake()
    {
        MaxValue = 100;
        Value = MaxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
        {
            Value = Mathf.Clamp(Value - damage, 0, Value);
            Changed?.Invoke(Value);
        }

        if (Value <= 0)
            Die();
    }

    public void Heal(int healing)
    {
        if (healing > 0 && Value < MaxValue)
        {
            Value = Mathf.Clamp(Value + healing, Value, MaxValue);
            Changed?.Invoke(Value);
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }
}