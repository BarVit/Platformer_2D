using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money = 0;

    public void TakeCoin(int value)
    {
        _money += value;
    }
}