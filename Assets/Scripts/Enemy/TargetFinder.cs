using UnityEngine;
using System;

public class TargetFinder : MonoBehaviour
{
    public event Action<Player> Entered;
    public event Action<Player> Exited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Entered?.Invoke(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            Exited?.Invoke(null);
        }
    }
}