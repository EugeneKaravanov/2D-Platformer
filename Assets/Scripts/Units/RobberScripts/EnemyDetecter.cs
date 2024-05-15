using UnityEngine;

public class EnemyDetecter : MonoBehaviour
{
    public PlayerInput Player { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInput playerInput))
            Player = playerInput;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInput playerInput))
            Player = null;
    }
}
