using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);

    public float HorizontalDirection { get; private set; }
    public bool IsTryingJump { get; private set; }
    public bool IsTryingAttack { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            IsTryingJump = true;

        if (Input.GetMouseButton(0))
            IsTryingAttack = true;

        HorizontalDirection = Input.GetAxisRaw(Horizontal);
    }

    public void DeActivateJumpTrying()
    {
        IsTryingJump = false;
    }

    public void DeActivateAttackTrying()
    {
        IsTryingAttack = false;
    }
}
