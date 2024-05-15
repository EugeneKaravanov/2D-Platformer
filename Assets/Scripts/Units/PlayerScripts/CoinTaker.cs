using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof (Wallet))]
public class CoinTaker : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.TryGetComponent(out Coin coin) && transform.TryGetComponent(out Player player))
        {
            _wallet.TakeCoin();
            Destroy(collider.gameObject);
        }
    }
}
