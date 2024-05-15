using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 3f;
    private Quaternion _turnLeft = Quaternion.Euler(0, 180f, 0);
    private Quaternion _turnRight = Quaternion.identity;

    public void Move(float direction)
    {
        transform.Translate(new Vector2(Math.Abs(direction), 0) * _speed * Time.deltaTime);
        Rotate(direction);
    }

    private void Rotate(float direction)
    {
        if (direction < 0)
        {
            transform.rotation = _turnLeft;
        }
        else if (direction > 0)
        {
            transform.rotation = _turnRight;
        }
    }
}
