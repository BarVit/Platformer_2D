using UnityEngine;
using System;

public class PursuitStateActivator : MonoBehaviour, IEnemyStateActivable
{
    [SerializeField] private EnemyStatePursuer _pursuer;

    public event Action<Player, IEnemyStateActivable> Insided;

    public EnemyState GetState(Player player)
    {
        _pursuer.SetTarget(player);
        return _pursuer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Insided?.Invoke(player, this);
        }
    }
}