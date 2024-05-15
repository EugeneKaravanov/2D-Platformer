using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class BaseHealthBarView : BaseHealthView
{
    public Slider HealthBar { get; private set; }

    private void Awake()
    {
        HealthBar = GetComponent<Slider>();
    }

    private void Start()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = Heath.MaxValue;
        HealthBar.value = Heath.MaxValue;
    }
}
