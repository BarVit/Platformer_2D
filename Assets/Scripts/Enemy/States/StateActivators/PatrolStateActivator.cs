using System;
using UnityEngine;

public class PatrolStateActivator : MonoBehaviour, IEnemyStateActivable
{
    [SerializeField] private EnemyStatePatroller _patroller;

    public event Action<Player, IEnemyStateActivable> OutSided;

    public EnemyState GetState(Player player)
    {
        return _patroller;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            OutSided?.Invoke(null, this);
        }
    }
}