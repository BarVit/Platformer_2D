using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int CoinsCount { get; private set; }

    private void Awake()
    {
        CoinsCount = 0;
    }

    public void GetCoin()
    {
       CoinsCount++;
    }
}