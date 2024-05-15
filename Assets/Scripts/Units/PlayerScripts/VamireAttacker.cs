using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class VamireAttacker : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _delayBetweenAttacks;
    [SerializeField] private float _damagePerAttack;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private TargetsDetecter _targetDetecter;
    [SerializeField] private VampireAttackAreaView _vampireAttackAreaView;

    public event Action DurationLeftChanged;

    private Coroutine _currentCoroutine;
    private Health _health;

    public bool IsAttcking {  get; private set; }
    public float DurationLeft { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void TryDoVampireAttack()
    {
        if(_targetDetecter.TryGetNearestTarget(out Health target))
        {
            if (_currentCoroutine == null)
                _currentCoroutine = StartCoroutine(VampireAttackCoroutine(target));
        }
    }

    private IEnumerator VampireAttackCoroutine(Health target)
    {
        WaitForSeconds time = new WaitForSeconds(_delayBetweenAttacks);

        DurationLeft = _duration;
        IsAttcking = true;
        _vampireAttackAreaView.Active();
        _buttonText.color = Color.red;

        while (DurationLeft > 0 && _targetDetecter.IsTargetInList(target))
        {
            _health.TakeHeal(target.TakeDamage(_damagePerAttack));
            DurationLeft -= _delayBetweenAttacks;
            DurationLeftChanged?.Invoke();
            yield return time;
        }

        DurationLeft = 0;
        DurationLeftChanged?.Invoke();

        IsAttcking = false;
        _vampireAttackAreaView.Deactive();
        _buttonText.color = Color.green;
        _currentCoroutine = null;
    }
}
