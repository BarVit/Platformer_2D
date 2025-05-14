using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    public Player Target { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            SetTarget(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            SetTarget(null);
        }
    }

    private void SetTarget(Player target)
    {
        Target = target;
    }
}