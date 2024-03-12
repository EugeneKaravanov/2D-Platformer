using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 3f;

    public void Move(float direction)
    {
        Debug.Log(direction);
        transform.Translate(new Vector2(_speed * Math.Abs(direction), 0) * Time.deltaTime);
    }
}
