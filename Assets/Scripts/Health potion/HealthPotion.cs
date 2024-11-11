using System;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private int _healingAmount = 10;

    public event Action<HealthPotion> Taken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerHealth player))
        {
            player.Heal(_healingAmount);
            Taken.Invoke(this);
        }
    }
}