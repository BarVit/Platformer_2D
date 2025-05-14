using System;
using UnityEngine;

public class PatrolStateActivator : EnemyStateActivator
{
    [SerializeField] private EnemyStatePatroller _patroller;

    public event Action<Player, EnemyStateActivator> OutSided;

    public override EnemyState2 GetState()
    {
        Debug.Log("return _patroller");
        return _patroller;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            Debug.Log("player exited");
            OutSided?.Invoke(null, this);
        }
    }
}