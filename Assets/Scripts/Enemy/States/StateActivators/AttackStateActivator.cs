using System;
using UnityEngine;

public class AttackStateActivator : MonoBehaviour, IEnemyStateActivable
{
    [SerializeField] private EnemyStateAttacker _attacker;
    [SerializeField] private AnimationHandler _animationHandler;

    public event Action<Player, IEnemyStateActivable> Insided;

    public EnemyState GetState(Player player)
    {
        return _attacker;
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out Player player))
    //    {
    //        Insided?.Invoke(player, this);
    //    }
    //}
}