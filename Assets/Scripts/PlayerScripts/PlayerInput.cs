using UnityEngine;

[RequireComponent(typeof(PlayerMovementView))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerAttacker))]
[RequireComponent(typeof(AttackView))]
[RequireComponent(typeof(Pause))]
[RequireComponent(typeof(Heath))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);

    private PlayerMovement _playerMovement;
    private PlayerMovementView _playerMovementView;
    private PlayerJumper _playerJumper;
    private PlayerAttacker _playerAttack;
    private AttackView _playerAttackView;
    private Pause _pause;
    private Heath _heath;
    private float _direction;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovementView = GetComponent<PlayerMovementView>();
        _playerJumper = GetComponent<PlayerJumper>();
        _playerAttack = GetComponent<PlayerAttacker>();
        _playerAttackView = GetComponent<AttackView>();
        _pause = GetComponent<Pause>();
        _heath = GetComponent<Heath>();
    }

    private void Update()
    {
        if (_pause.IsPaused == false && _heath.HeathPoints > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerJumper.TryJump();
            }

            if (Input.GetMouseButton(0))
            {
                _playerAttack.TryAttack();
                _playerAttackView.SetAttackView();
            }

            _direction = Input.GetAxisRaw(Horizontal);
            _playerMovement.Move(_direction);
            _playerMovementView.SetView(_direction);
        }
    }
}
