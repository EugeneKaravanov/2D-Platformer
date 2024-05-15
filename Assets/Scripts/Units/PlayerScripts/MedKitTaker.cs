using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Health))]
public class MedKitTaker : MonoBehaviour
{
    private Health _heath;

    private void Awake()
    {
        _heath = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.TryGetComponent(out MedKit medKit))
        {
            _heath.TakeHeal(medKit.HealPower);
            Destroy(collider.gameObject);
        }
    }
}
