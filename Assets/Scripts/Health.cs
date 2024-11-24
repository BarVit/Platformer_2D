using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health = 100;

    private int _maxHealth = 100;

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
            _health = Mathf.Clamp(_health - damage, 0, _health);
    }

    public void Heal(int healing)
    {
        if (_health < _maxHealth)
            _health = Mathf.Clamp(_health + healing, _health, _maxHealth);
    }
}