using UnityEngine;

[RequireComponent(typeof(Wallet), typeof(Health))]
public class ItemPicker : MonoBehaviour, IPickable
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
            item.Pick(this);
    }

    public void Pick(Coin coin)
    {
        _wallet.PickCoin(coin.Value);
    }

    public void Pick(HealthPotion healthPotion)
    {
        _playerHealth.Heal(healthPotion.HealingAmount);
    }
}