using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Weapon), typeof(IDamageable))]
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
        Collider2D[] targets = Physics2D.OverlapCircleAll(_attackPoint.position, _weapon.Range);

        IDamageable[] damageTakers = targets.Where(target => target.GetComponent<IDamageable>() != null)
            .Select(target => target.GetComponent<IDamageable>()).ToArray();

        foreach (IDamageable damageTaker in damageTakers)
        {
            if (damageTaker != _attacker)
                damageTaker.TakeDamage(_weapon.Damage);
        }
    }
}