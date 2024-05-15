public class RobberAttacker : Attacker
{
    public void Attack(PlayerInput player)
    {
        if (player.TryGetComponent(out Health heath))
            heath.TakeDamage(Damage);
    }
}
