using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coinsCount;

    public void TakeCoin()
    {
        _coinsCount++;
    }
}
