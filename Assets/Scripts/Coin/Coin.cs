using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour
{
    public event Action<Coin> Taken;

    private string _animationName = "Idle";

    private void Awake()
    {
        GetComponent<Animator>().Play(_animationName, 0, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent(out Player player))
        {
            player.TakeCoin();
            Taken?.Invoke(this);
        }
    }
}