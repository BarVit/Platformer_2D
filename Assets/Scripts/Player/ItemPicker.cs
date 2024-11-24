using UnityEngine;

[RequireComponent(typeof(Wallet), typeof(Health))]
public class ItemPicker : MonoBehaviour
{
    private Wallet _wallet;
    private Health _playerHealth;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _playerHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Item item))
        {
            if (item is Coin)
            {
                _wallet.TakeCoin(((Coin)item).Value);
                item.Take();
            }
            else if (item is HealthPotion)
            {
                _playerHealth.Heal(((HealthPotion)item).HealingAmount);
                item.Take();
            }
        }
    }
}