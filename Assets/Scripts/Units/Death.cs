using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D), typeof(Health))]
public class Death : MonoBehaviour
{
    private const string IsDead = nameof(IsDead);

    [SerializeField] private AnimationClip _deathAnimation;
    [SerializeField] private Sprite _deathImage;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _capsuleCollider;
    private Rigidbody2D _rigidbody;
    private Health _heath;

    private void OnEnable()
    {
        _heath.UnitDead += Die;
    }

    private void OnDisable()
    {
        _heath.UnitDead -= Die;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _heath = GetComponent<Health>();
    }

    private void Die()
    {
        StartCoroutine(StartDieCorutine());
    }

    private IEnumerator StartDieCorutine()
    {
        float waitTimeafterDeath = 3;

        _animator.SetBool(IsDead, true);

        yield return new WaitForSeconds(_deathAnimation.length);

        _animator.enabled = false;
        _spriteRenderer.sprite = _deathImage;
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _capsuleCollider.enabled = false;

        yield return new WaitForSeconds(waitTimeafterDeath);

        Destroy(gameObject);
    }
}
