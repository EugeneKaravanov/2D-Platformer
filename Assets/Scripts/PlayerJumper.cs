using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _jumpSpeed = 10f;
    private bool _isStayOnGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isStayOnGround)
            _rigidbody.velocity = new Vector3(0, _jumpSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isStayOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isStayOnGround = false;
        }
    }
}
