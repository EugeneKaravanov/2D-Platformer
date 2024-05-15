using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Pause))]
public class AttackView : MonoBehaviour
{
    private const string IsAttacking = nameof(IsAttacking);

    [SerializeField] private AnimationClip _attackAnimation;

    private Pause _pause;
    private Animator _animator;

    private void Awake()
    {
        _pause = GetComponent<Pause>();
        _animator = GetComponent<Animator>();
    }

    public void ActivateAttackView()
    {
        _animator.SetTrigger(IsAttacking);
        StartCoroutine(_pause.SetPause(_attackAnimation.length));   
    }
}
