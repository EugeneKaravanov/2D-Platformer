using System.Collections;
using UnityEngine;

public class SmoothHealthBar : BaseHealthBarView
{
    private float _fps = 60;
    private float _changingTimeInSeconds = 0.5f;
    private Coroutine _coroutine;

    protected override void ChangeHealthView()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeHeathBarValueCoroutine());
    }

    private IEnumerator ChangeHeathBarValueCoroutine()
    {
        float changingStepsCount = _changingTimeInSeconds * _fps;
        float changingValueByStep = (Heath.Value - HealthBar.value) / changingStepsCount;
        WaitForSeconds delay = new WaitForSeconds(_changingTimeInSeconds / changingStepsCount);

        for (int i = 0; i < changingStepsCount; i++) 
        {
            HealthBar.value += changingValueByStep;
            yield return delay;
        }
    }
}
