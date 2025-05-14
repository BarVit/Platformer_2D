using UnityEngine;
using System;

public class PursuitStateActivator : EnemyStateActivator
{
    [SerializeField] private EnemyStatePursuer _pursuer;

    public event Action<Player, EnemyStateActivator> Insided;

    public override EnemyState2 GetState()
    {
        Debug.Log("return _pursuer");
        return _pursuer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Debug.Log("player entered");
            Insided?.Invoke(player, this);
        }
    }
}