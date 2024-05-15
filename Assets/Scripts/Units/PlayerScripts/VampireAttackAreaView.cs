using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VampireAttackAreaView : MonoBehaviour
{
    [SerializeField] private VamireAttacker _vamireAttacker;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.enabled = false;
    }

    public void Active()
    {
        _spriteRenderer.enabled = true;
    }

    public void Deactive()
    {
        if (_vamireAttacker.IsAttcking == false)
        {
            _spriteRenderer.enabled = false;
        }
    }
}
