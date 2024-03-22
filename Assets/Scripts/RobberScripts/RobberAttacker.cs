public class RobberAttacker : Attacker
{
    public void Attack(PlayerInput player)
    {
        player.transform.GetComponent<Heath>().TakeDamage(Damage);
    }
}
