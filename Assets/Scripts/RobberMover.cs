using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RobberMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private int _currentWaypointNumber = 0;
    private int _decimalNumbers = 3;
    private Vector2 _currentPointPosition;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Math.Round(transform.position.x, _decimalNumbers) == Math.Round(_waypoints[_currentWaypointNumber].position.x, _decimalNumbers))
        {
            _currentWaypointNumber = (_currentWaypointNumber + 1) % _waypoints.Count;
        }

        _currentPointPosition = _waypoints[_currentWaypointNumber].position;
        _currentPointPosition.y = transform.position.y;
        transform.position = Vector2.MoveTowards(transform.position, _currentPointPosition, _speed * Time.deltaTime);

        FlipSprite();
    }

    private void FlipSprite()
    {
        if (_waypoints[_currentWaypointNumber].position.x < transform.position.x)
            _spriteRenderer.flipX = true;
        else if (_waypoints[_currentWaypointNumber].position.x > transform.position.x)
            _spriteRenderer.flipX = false;
    }
}
