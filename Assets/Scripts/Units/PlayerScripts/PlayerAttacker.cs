using UnityEngine;

public class PlayerAttacker : Attacker
{
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private float range;

    public void TryAttack()
    {
        RaycastHit2D enemy = Physics2D.Raycast(transform.position, transform.right, range, _enemyMask);

        if (enemy)
        {
            if (enemy.transform.TryGetComponent(out Health heath))
                heath.TakeDamage(Damage);
        }
    }
}
