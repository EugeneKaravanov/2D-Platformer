using UnityEngine;

public abstract class BaseHealthView : MonoBehaviour
{
    [field: SerializeField] public Health Heath { get; private set; }

    private void OnEnable()
    {
        Heath.Changed += ChangeHealthView;
    }

    private void OnDisable()
    {
        Heath.Changed -= ChangeHealthView;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }

    protected abstract void ChangeHealthView();
}
