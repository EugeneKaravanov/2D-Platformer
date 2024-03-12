using UnityEngine;

[RequireComponent(typeof(PlayerMovementView))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerJumper))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);

    private PlayerMovement _playerMovement;
    private PlayerMovementView _playerMovementView;
    private PlayerJumper _playerJumper;
    private float _direction;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovementView = GetComponent<PlayerMovementView>();
        _playerJumper = GetComponent<PlayerJumper>();
    }

    private void Update()
    {
        _direction = Input.GetAxisRaw(Horizontal);
        _playerMovement.Move(_direction);
        _playerMovementView.RotateSprite(_direction);
        _playerMovementView.SetSpeedInAnimator(_direction);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerJumper.TryJump();
        }
    }
}
