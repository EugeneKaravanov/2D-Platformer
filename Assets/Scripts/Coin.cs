using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Wallet>(out Wallet wallet))
        {
            wallet.TakeCoin();
            Destroy(gameObject);
        }
    }
}
