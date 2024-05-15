using System.Collections.Generic;
using UnityEngine;

public class TargetsDetecter : MonoBehaviour
{
    private List<Health> _potentialTargets = new List<Health>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health robber))
        {
            if (robber.TryGetComponent(out RobberAI robberAI))
            {
                _potentialTargets.Add(robber);
                robber.UnitDead += DeleteDeadUnit;        
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health robber))
        {
            if (robber.TryGetComponent(out RobberAI robberAI)) 
            {
                _potentialTargets.Remove(robber);
                robber.UnitDead -= DeleteDeadUnit;
            }
        }
    }
    public bool TryGetNearestTarget(out Health target)
    {
        target = null;

        if (_potentialTargets.Count == 0)
            return false;

        target = _potentialTargets[0];

        for (int i = 0; _potentialTargets.Count > i; i++) 
            if ((_potentialTargets[i].transform.position - transform.position).magnitude < (target.transform.position - transform.position).magnitude)
            {
                target = _potentialTargets[i];
            }

        return true;
    }

    public bool IsTargetInList(Health target)
    {
        return _potentialTargets.Contains(target);
    }

    private void DeleteDeadUnit()
    {
        for (int i = 0; i < _potentialTargets.Count; i++) 
        { 
            if (_potentialTargets[i].Value == 0)
            {
                _potentialTargets[i].UnitDead -= DeleteDeadUnit;
                _potentialTargets.Remove(_potentialTargets[i]);
                break;
            }
        }
    }
}
