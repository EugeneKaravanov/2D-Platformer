using UnityEngine;

public class MedKit : Item
{
    private float _healPower = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerInput>(out PlayerInput player))
        {
            player.GetComponent<Heath>().ChangeHeathValue(_healPower);
            Destroy(gameObject);
        }
    }
}
