using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health = 100;

    private int _maxHealth = 100;

    public void Heal(int healing)
    {
        if (_health < _maxHealth)
            _health = Mathf.Clamp(_health + healing, _health, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
            _health = Mathf.Clamp(_health - damage, 0, _health);
    }
}