using System;
using UnityEngine;

public class Heath : MonoBehaviour
{
    private const string IsDead = nameof(IsDead);

    [SerializeField] private float _maxHeathPoints;

    public event Action UnitDead;

    public float HeathPoints { get; private set; }

    private void Start()
    {
        HeathPoints = _maxHeathPoints;
    }

    public void TakeHeal(float heal)
    {
        HeathPoints = Math.Clamp(HeathPoints + heal, 0, _maxHeathPoints);
    }

    public void TakeDamage(float damage)
    {
        HeathPoints = Math.Clamp(HeathPoints - damage, 0, _maxHeathPoints);

        if (HeathPoints == 0)
            UnitDead?.Invoke();
    }
}
