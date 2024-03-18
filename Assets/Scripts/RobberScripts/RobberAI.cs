using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Heath))]
[RequireComponent(typeof(Pause))]
[RequireComponent(typeof(RobberPatroller))]
[RequireComponent(typeof(RobberPursuer))]
[RequireComponent(typeof(RobberAttacker))]
[RequireComponent(typeof(AttackView))]
public class RobberAI : MonoBehaviour
{
    const string PursuitArea = nameof(PursuitArea);
    const string AttackArea = nameof(AttackArea);

    private Heath _heath;
    private Pause _pause;
    private EnemyDetecter _enemyPursuitArea;
    private EnemyDetecter _enemyAttackArea;
    private RobberPatroller _robberPatroller;
    private RobberPursuer _robberPursuer;
    private RobberAttacker _robberAttacker;
    private AttackView _attackView;

    private void Awake()
    {
        _heath = GetComponent<Heath>();
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
        if (_pause.IsPaused == false && _heath.HeathPoints > 0)
        {
            if (_enemyAttackArea != null && _enemyAttackArea.Player != null)
            {
                _robberAttacker.Attack(_enemyAttackArea.Player);
                _attackView.SetAttackView();

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
