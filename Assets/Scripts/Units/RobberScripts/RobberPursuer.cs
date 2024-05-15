using UnityEngine;

public class RobberPursuer : RobberMover
{
    public void Chase(PlayerInput player)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
    }
}
