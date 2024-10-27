using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour
{
    private int _value;
    private int _minValue = 1;
    private int _maxValue = 4;
    private int _idleHash = Animator.StringToHash("Idle");

    public event Action<Coin> Taken;

    private void Awake()
    {
        GetComponent<Animator>().Play(_idleHash, 0, 0.5f);
        _value = UnityEngine.Random.Range(_minValue, _maxValue + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent(out Wallet wallet))
        {
            wallet.TakeCoin(_value);
            Taken?.Invoke(this);
        }
    }
}