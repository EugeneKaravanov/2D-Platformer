using System;
using System.Collections.Generic;
using UnityEngine;

public class RobberPatroller : RobberMover
{
    [SerializeField] private List<Transform> _waypoints;

    private int _currentWaypointNumber = 0;
    private int _decimalNumbers = 1;
    private Vector2 _currentPointPosition;
    private Quaternion _turnLeft = Quaternion.Euler(0, 180f, 0);
    private Quaternion _turnRight = Quaternion.identity;

    private void Awake()
    {
        _currentPointPosition = _waypoints[_currentWaypointNumber].position;
    }
    public void Patrol()
    {
        TrySetNewWayPoint();
        transform.position = Vector2.MoveTowards(transform.position, _currentPointPosition, Speed * Time.deltaTime);
        Rotate();
    }

    private void TrySetNewWayPoint()
    {
        if (Math.Round(transform.position.x, _decimalNumbers) == Math.Round(_waypoints[_currentWaypointNumber].position.x, _decimalNumbers))
        {
            _currentWaypointNumber = ++_currentWaypointNumber % _waypoints.Count;
            _currentPointPosition = _waypoints[_currentWaypointNumber].position;
            _currentPointPosition.y = transform.position.y;
        }
    }

    private void Rotate()
    {
        if (_currentPointPosition.x < transform.position.x)
        {
            transform.rotation = _turnLeft;
        }
        else if (_currentPointPosition.x > transform.position.x)
        {
            transform.rotation = _turnRight;
        }
    }
}
