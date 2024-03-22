using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Heath))]
public class MedKitTaker : MonoBehaviour
{
    private Heath _heath;

    private void Awake()
    {
        _heath = GetComponent<Heath>();
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
