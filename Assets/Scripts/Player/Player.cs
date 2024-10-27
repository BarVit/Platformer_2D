using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    public void TakeCoin()
    {
        _wallet.GetCoin();
    }
}