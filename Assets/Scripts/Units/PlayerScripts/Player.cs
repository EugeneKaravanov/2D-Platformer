using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerJumper), typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerMovementView), typeof(PlayerAttacker), typeof(AttackView))]
[RequireComponent(typeof(Pause), typeof(Health))]
public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerJumper _playerJumper;
    private PlayerMovement _playerMovement;
    private PlayerMovementView _playerMovementView;
    private PlayerAttacker _playerAttacker;
    private AttackView _attackerView;
    private Pause _pause;
    private Health _heath;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovementView = GetComponent<PlayerMovementView>();
        _playerJumper = GetComponent<PlayerJumper>();
        _playerAttacker = GetComponent<PlayerAttacker>();
        _attackerView = GetComponent<AttackView>();
        _pause = GetComponent<Pause>();
        _heath = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        if (_pause.IsPaused == false && _heath.Value > 0)
        {
            if (_playerInput.IsTryingJump)
                _playerJumper.TryJump();

            _playerMovement.Move(_playerInput.HorizontalDirection);
            _playerMovementView.SetSpeedInAnimator(_playerInput.HorizontalDirection);
        }

        _playerInput.DeActivateJumpTrying();
    }

    private void Update()
    {
        if (_pause.IsPaused == false && _heath.Value > 0)
        {
            if (_playerInput.IsTryingAttack)
            {
                _playerAttacker.TryAttack();
                _attackerView.ActivateAttackView();
            }
        }

        _playerInput.DeActivateAttackTrying();
    }
}
