using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Weapon))]
public class DamageApllier : MonoBehaviour
{
    [SerializeField] private AnimationEvent _animationEvent;
    [SerializeField] private Transform _attackPoint;

    private const string LayerName = "Units";

    private Weapon _weapon;
    private IDamageable _attacker;

    private void Awake()
    {
        _attacker = GetComponent<IDamageable>();
        _weapon = GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        _animationEvent.Attacking += ApplyDamage;
    }

    private void OnDisable()
    {
        _animationEvent.Attacking -= ApplyDamage;
    }

    private void ApplyDamage()
    {
        LayerMask layerMask = LayerMask.GetMask(LayerName);
        Collider2D[] targets = Physics2D.OverlapCircleAll(_attackPoint.position, _weapon.Range, layerMask);
        IDamageable[] damageTakers = targets.Where(target => target.GetComponent<IDamageable>() != null)
            .Select(target => target.GetComponent<IDamageable>()).ToArray();

        foreach (IDamageable damageTaker in damageTakers)
        {
            if (damageTaker != _attacker)
                damageTaker.TakeDamage(_weapon.Damage);
        }
    }
}