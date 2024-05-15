using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovementView : MonoBehaviour
{
    private const string Speed = nameof(Speed);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeedInAnimator(float direction)
    {
        _animator.SetFloat(Speed, Math.Abs(direction));
    }
}
