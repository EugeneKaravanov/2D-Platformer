using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovementView : MonoBehaviour
{
    private const string Speed = nameof(Speed);

    private Animator _animator;
    private Quaternion _turnLeft = Quaternion.Euler(0, 180f, 0);
    private Quaternion _turnRight = Quaternion.identity;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void RotateSprite(float direction)
    {
        if (direction < 0)
        {
            transform.rotation = _turnLeft;
        }
        else if (direction > 0)
        {
            transform.rotation = _turnRight;
        }
    }

    public void SetSpeedInAnimator(float direction)
    {
        _animator.SetFloat(Speed, Math.Abs(direction));
    }
}
