using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Changed;
    public event Action UnitDead;

    [field: SerializeField] public float MaxValue { get; private set; }
    public float Value { get; private set; }

    private void OnEnable()
    {
        Value = MaxValue;
    }

    public void TakeHeal(float heal)
    {
        Value = Math.Clamp(Value + heal, 0, MaxValue);
        Changed?.Invoke();
    }

    public float TakeDamage(float damage)
    {
        float dealtDamage;

        if (Value - damage >= 0)
            dealtDamage = damage;
        else
            dealtDamage = Value;

        Value = Math.Clamp(Value - damage, 0, MaxValue);
        Changed?.Invoke();

        if (Value == 0)
            UnitDead?.Invoke();

        return dealtDamage;
    }
}
