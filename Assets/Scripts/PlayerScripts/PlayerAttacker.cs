using UnityEngine;

public class PlayerAttacker : Attacker
{
    [SerializeField] private LayerMask _enemyMask;

    private float range = 5;

    public void TryAttack()
    {
        RaycastHit2D enemy = Physics2D.Raycast(transform.position, transform.right, range, _enemyMask);

        if (enemy)
        {
            enemy.transform.GetComponent<Heath>().ChangeHeathValue(-Damage);
        }
    }
}
