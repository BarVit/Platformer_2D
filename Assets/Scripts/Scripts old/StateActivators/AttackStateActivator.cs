using System;
using UnityEngine;

public class AttackStateActivator : EnemyStateActivator
{
    [SerializeField] private EnemyStateAttacker _attacker;
    [SerializeField] private EnemyStatePursuer _pursuer;

    public event Action<Player, EnemyStateActivator> AttackRanged;

    private void OnEnable()
    {
        _pursuer.EnteredAttackArea += InvokeAttackActivator;
    }

    private void OnDisable()
    {
        _pursuer.EnteredAttackArea -= InvokeAttackActivator;
    }

    public override EnemyState2 GetState()
    {
        Debug.Log("return _attacker");
        return _attacker;
    }

    private void InvokeAttackActivator(Player player)
    {
        Debug.Log("player in attack range");
        AttackRanged?.Invoke(player, this);
    }
}