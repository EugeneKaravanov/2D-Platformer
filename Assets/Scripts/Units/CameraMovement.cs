using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Health _health;

    private float _positionZ;
    private bool _isFolowoing = true;

    private void OnEnable()
    {
        _health.UnitDead += OffFolowing;
    }

    private void OnDisable()
    {
        _health.UnitDead -= OffFolowing;
    }

    private void Start()
    {
        _positionZ = transform.position.z;
    }

    private void Update()
    {
        if (_isFolowoing)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _positionZ);
        }
    }

    private void OffFolowing()
    {
        _isFolowoing = false;
    }
}
