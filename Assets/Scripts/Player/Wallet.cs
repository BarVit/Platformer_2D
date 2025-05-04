using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money = 0;

    public void PickCoin(int value)
    {
        if(value > 0)
            _money += value;
    }
}