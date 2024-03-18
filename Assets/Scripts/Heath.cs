using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Heath : MonoBehaviour
{
    private const string IsDead = nameof(IsDead);

    [SerializeField] private float _maxHeathPoints;
    [SerializeField] private AnimationClip _deathAnimation;
    [SerializeField] private Sprite _deathImage;

    public event Action UnitDead;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;

    public float HeathPoints { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        HeathPoints = _maxHeathPoints;
    }

    public void ChangeHeathValue(float value)
    {
        if(HeathPoints + value < 0)
        {
            HeathPoints = 0;
        }
        else if (HeathPoints + value > _maxHeathPoints)
        {
            HeathPoints = _maxHeathPoints;
        }
        else
        {
            HeathPoints += value;
        }

        if (HeathPoints == 0)
            StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        float waitTimeafterDeath = 3;

        UnitDead?.Invoke();
        _animator.SetBool(IsDead, true);

        yield return new WaitForSeconds(_deathAnimation.length);

        _animator.enabled = false;
        _spriteRenderer.sprite = _deathImage;
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _boxCollider.enabled = false;

        yield return new WaitForSeconds(waitTimeafterDeath);

        Destroy(gameObject);
    }
}
