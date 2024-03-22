using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rigidbody;
    private float _jumpSpeed = 10f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void TryJump()
    {
        if (IsStayOnGround())
        {
            _rigidbody.velocity = new Vector3(0, _jumpSpeed);
        }
    }

    private bool IsStayOnGround()
    {
        return Physics2D.OverlapCircle(transform.position, transform.localScale.y / 2 + 1, _groundMask);
    }
}
