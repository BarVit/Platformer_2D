using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health = 100;

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
            _health = Mathf.Clamp(_health - damage, 0, _health);
    }
}