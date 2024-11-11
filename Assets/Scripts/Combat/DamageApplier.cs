using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Weapon))]
public class DamageApllier : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;

    private IDamageable _attacker;
    private Weapon _weapon;

    private void Awake()
    {
        _attacker = GetComponent<IDamageable>();
        _weapon = GetComponent<Weapon>();
    }

    public void Apply()
    {
        Collider2D[] damageTakers = Physics2D.OverlapCircleAll(_attackPoint.position, _weapon.Range);

        damageTakers = damageTakers.Where(enemy => enemy.GetComponent<IDamageable>() != null).ToArray();

        foreach (Collider2D damageTaker in damageTakers)
        {
            IDamageable target = damageTaker.GetComponent<IDamageable>();

            if (target != _attacker)
                target.TakeDamage(_weapon.Damage);
        }
    }
}