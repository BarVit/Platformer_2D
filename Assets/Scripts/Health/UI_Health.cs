using UnityEngine;

public abstract class UI_Health : MonoBehaviour
{
    [SerializeField] protected Health Health;

    public abstract void OnHealthChanged(int health);

    private void OnEnable()
    {
        Health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        Health.Changed -= OnHealthChanged;
    }
}