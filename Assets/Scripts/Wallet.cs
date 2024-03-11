using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinsCount;

    public void TakeCoin()
    {
        _coinsCount++;
    }
}
