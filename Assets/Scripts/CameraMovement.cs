using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private float _positionZ;

    private void Start()
    {
        _positionZ = transform.position.z;
    }

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _positionZ);
    }
}
