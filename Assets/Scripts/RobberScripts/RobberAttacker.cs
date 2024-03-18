using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberAttacker : Attacker
{
    public void Attack(PlayerInput player)
    {
        player.transform.GetComponent<Heath>().ChangeHeathValue(-Damage);
    }
}
