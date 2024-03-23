public class RobberAttacker : Attacker
{
    public void Attack(PlayerInput player)
    {
        if (player.TryGetComponent(out Heath heath))
            heath.TakeDamage(Damage);
    }
}
