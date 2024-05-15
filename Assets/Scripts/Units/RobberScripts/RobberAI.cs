using UnityEngine;

[RequireComponent(typeof(Health), typeof(Pause), typeof(RobberPatroller))]
[RequireComponent(typeof(RobberPursuer), typeof(RobberAttacker), typeof(AttackView))]
public class RobberAI : MonoBehaviour
{
    private const string PursuitArea = nameof(PursuitArea);
    private const string AttackArea = nameof(AttackArea);

    private Health _heath;
    private Pause _pause;
    private EnemyDetecter _enemyPursuitArea;
    private EnemyDetecter _enemyAttackArea;
    private RobberPatroller _robberPatroller;
    private RobberPursuer _robberPursuer;
    private RobberAttacker _robberAttacker;
    private AttackView _attackView;

    private void Awake()
    {
        _heath = GetComponent<Health>();
        _pause = GetComponent<Pause>();
        transform.Find(PursuitArea).TryGetComponent(out _enemyPursuitArea);
        transform.Find(AttackArea).TryGetComponent(out _enemyAttackArea);
        _robberPatroller = GetComponent<RobberPatroller>();
        _robberPursuer = GetComponent<RobberPursuer>();
        _robberAttacker = GetComponent<RobberAttacker>();
        _attackView = GetComponent<AttackView>();
    }

    void Update()
    {
        if (_pause.IsPaused == false && _heath.Value > 0)
        {
            if (_enemyAttackArea != null && _enemyAttackArea.Player != null)
            {
                _robberAttacker.Attack(_enemyAttackArea.Player);
                _attackView.ActivateAttackView();

            }
            else if (_enemyPursuitArea != null && _enemyPursuitArea.Player != null)
            {
                _robberPursuer.Chase(_enemyPursuitArea.Player);
            }
            else
            {
                _robberPatroller.Patrol();
            }
        }
    }
}
