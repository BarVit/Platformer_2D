using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money = 0;

    public void TakeCoin(int value)
    {
        _money += value;
    }
}